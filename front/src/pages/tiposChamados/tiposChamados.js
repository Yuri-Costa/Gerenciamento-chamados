import { Component } from 'react';
import { Link } from 'react-router-dom';

import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";

import logo from "../../assets/img/logo.png";

import Rodape from '../../components/rodape/rodape';
import Titulo from '../../components/titulo/titulo';

class TiposChamados extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaTiposChamados : [],
            titulo : '',
            idTipoChamadoAlterado : 0
        }
    }

    // Função responsável por fazer a requisição e trazer a lista de tipos Chamado
    buscarTiposChamados = () => {
        console.log('agora vamos fazer a chamada para API para atualizar a lista');

        // Faz a chamada para a API usando o fetch
        fetch('http://localhost:5000/api/tiposChamados', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        // Fetch retorna uma Promise que se resolve em uma resposta ( Response )
        // .then(resposta => console.log(resposta))

        // O método .json() retorna um objeto JavaScript        
        // .then(resposta => console.log(resposta.json()))

        // Em outras palavras, define o tipo de dado do retorno da requisição ( JSON )
        // .then(resposta => resposta.json())

        // .then(resposta => {
        //     // Caso a requisição retorne um status code 200,
        //     if (resposta.status === 200) {
        //         // Atualiza o state listaTipoChamados com o corpo da requisição após o método .json()
        //         resposta.json().then(resposta => this.setState({ listaTiposChamados : resposta }));
        //     };
        // })

        // Outra forma, com tratamento de erro
        .then(resposta => {
            // Caso a requisição não retorne um status code 200,
            if (resposta.status !== 200) {
                throw Error();
            };
            return resposta.json();
        })
        
        // e atualiza o state listaTiposChamados com os dados obtidos
        .then(resposta => this.setState({ listaTiposChamados : resposta }))
        // .then(data => console.log(data))
        
        // Caso ocorra algum erro, mostra no console do navegador
        .catch((erro) => console.log(erro))
    };

    // Chama a função buscarTiposChamados() assim que o componente é renderizado
    componentDidMount(){
        this.buscarTiposChamados();
    }

    // Atualiza o state titulo com o valor do input
    atualizaEstadoTitulo = async (event) => {
        await this.setState({ titulo : event.target.value })
        console.log(this.state.titulo)
    };

    // Função responsável por cadastrar um Tipo de Chamado
    cadastrarTipoChamado = (event) => {
        // Ignora o comportamento padrão do navegador
        event.preventDefault();

        // Caso algum Tipo de Chamado seja selecionado para edição,
        if (this.state.idTipoChamadoAlterado !== 0) {
            // faz a chamada para a API usando fetch e passando o ID do Tipo de Chamado que será atualizado na URL da requisição
            fetch('http://localhost:5000/api/tiposchamados/' + this.state.idTipoChamadoAlterado,
            {
                // Define o método da requisição ( PUT )
                method : 'PUT',

                // Define o corpo da requisição especificando o tipo ( JSON )
                body : JSON.stringify({
                    tituloTipoChamado : this.state.titulo
                }),

                // Define o cabeçalho da requisição
                headers : {
                    "Content-Type" : "application/json",
                    'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })

            .then(resposta => {
                // Caso a requisição retorne um status code 204,
                if (resposta.status === 204) {
                    console.log(
                        // Exibe no console do navegador a mensagem 'Tipo de Chamado x atualizado!', onde x é o ID do Tipo de Chamado atualizado
                        'Tipo de Chamado ' + this.state.idTipoChamadoAlterado + ' atualizado!',
                        // e informa qual é seu novo título
                        'Seu novo título agora é: ' + this.state.titulo
                    );
                };
            })

            // Então, atualiza a lista de Tipos de Chamados
            // sem o usuário precisar executar outra ação
            .then(this.buscarTiposChamados)

            // Faz a chamada para a função limparCampos()
            .then(this.limparCampos)
        }

        // Caso nenhum Tipo de Chamado tenha sido selecionado para editar, realiza o cadastro com a requisição abaixo
        else {
            // Faz a chamada para a API usando fetch
            fetch('http://localhost:5000/api/tiposchamados',
            {
                // Define o método da requisição ( POST )
                method : 'POST',

                // Define o corpo da requisição especificando o tipo ( JSON )
                // Em outras palavras, converte o state para uma string JSON
                body : JSON.stringify({ tituloTipoChamado : this.state.titulo }),

                // Define o cabeçalho da requisição
                headers : {
                    "Content-Type" : "application/json",
                    'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })

            // Exibe no console do navegador a mensagem 'Tipo de Chamado cadastrado!'
            .then(console.log('Tipo de Chamado cadastrado!'))

            // Caso ocorra algum erro,
            // exibe este erro no console do navegador
            .catch(erro => console.log(erro))

            // Então, atualiza a lista de Tipos de Eventos
            // sem o usuário precisar executar outra ação
            .then(this.buscarTiposChamados)

            // Faz a chamada para a função limparCampos()
            .then(this.limparCampos)
        }
    };

    // Recebe um tipo de Chamado da lista
    buscarTipoChamadoPorId = (tipoChamado) => {
        this.setState({
            // Atualiza o state idTipoChamadoAlterado com o valor do ID do Tipo de Chamado recebido
            idTipoChamadoAlterado : tipoChamado.idTipoChamado,
            // e o state titulo com o valor do titulo do Tipo de Chamado recebido
            titulo : tipoChamado.tituloTipoChamado
        }, () => {
            console.log(
                // Exibe no console do navegador o valor do ID do Tipo de Chamado recebido
                'O Tipo de Chamado ' + tipoChamado.idTipoChamado + ' foi selecionado, ',
                // o valor do state idTipoChamadoAlterado
                'agora o valor do state idTipoChamadoAlterado é: ' + this.state.idTipoChamadoAlterado,
                // e o valor do state titulo
                'e o valor do state titulo é: ' + this.state.titulo
            );
        });
    };

    // Função responsável por excluir um Tipo de Chamado
    excluirTipoChamado = (tipoChamado) => {
        // Exibe no console do navegador o ID do Tipo de Chamado recebido
        console.log('O Tipo de Chamado ' + tipoChamado.idTipoChamado + ' foi selecionado')

        // Faz a chamada para a API usando fetch passando o ID do Tipo de Evento recebido na URL da requisição
        fetch('http://localhost:5000/api/tiposchamado/' + tipoChamado.idTipoChamado,
        {
            // Define o método da requisição ( DELETE )
            method : 'DELETE',

            // Define o cabeçalho da requisição
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        // Caso a requisição retorne um status code 204,
        .then(resposta => {
            if (resposta.status === 204) {
                // Exibe no console do navegador a mensagem 'Tipo de Evento x excluído!' onde x é o ID do Tipo de Evento excluído
                console.log('Tipo de Chamado ' + tipoChamado.idTipoChamado + ' excluído!')
            };
        })

        // Caso ocorra alguma erro, exibe este erro no console do navegador
        .catch(erro => console.log(erro))

        // Então, atualiza a lista de Tipos de Eventos
        // sem o usuário precisar executar outra ação
        .then(this.buscarTiposChamado)
    }

    // Reseta os states titulo e idTipoEventoAlterado
    limparCampos = () => {
        this.setState({
            titulo : '',
            idTipoEventoAlterado : 0
        })
        // Exibe no console do navegador a mensagem 'Os states foram resetados!'
        console.log('Os states foram resetados!')
    }

    render(){
        return(
            <div>
                <header className="cabecalhoPrincipal">
                    <div className="container">
                    <Link to="/"><img src={logo} alt="Logo da Gufi" /></Link>

                    <nav className="cabecalhoPrincipal-nav">
                        Administrador
                    </nav>
                    </div>
                </header>

                <main className="conteudoPrincipal">
                    <section className="conteudoPrincipal-cadastro">
                        <Titulo tituloSeccao="Lista TiposChamado" />
                        {/* <h2 className="conteudoPrincipal-cadastro-titulo">Tipos de Chamados</h2> */}
                        <div className="container" id="conteudoPrincipal-lista">
                            <table id="tabela-lista">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Título</th>
                                    <th>Ação</th>
                                </tr>
                            </thead>

                                <tbody id="tabela-lista-corpo">
                                    {
                                        this.state.listaTiposChamados.map( (tipoChamado) => {
                                            return (
                                                <tr key={tipoChamado.idTipoChamado}>
                                                    <td>{tipoChamado.idTipoChamado}</td>
                                                    <td>{tipoChamado.tituloTipoChamado}</td>

                                                    {/* Faz a chamada da função buscarTipoChamadoPorId passando o Tipo de Chamado selecionado  */}
                                                    <td><button onClick={() => this.buscarTipoChamadoPorId(tipoChamado)} >Editar</button>

                                                    {/* Faz a chamada da função excluirTipoChamado passando o Tipo de Chamado selecionado  */}
                                                    <button onClick={() => this.excluirTipoChamado(tipoChamado)} >Excluir</button></td>
                                                </tr>
                                            );
                                        } )
                                    }
                                </tbody>
                            </table>
                        </div>
                    </section>

                    <section className="container" id="conteudoPrincipal-cadastro">
                        {/* Cadastro de Tipo de Chamado */}
                        <Titulo tituloSeccao="Cadastro de Tipos Chamados" />
                        {/* <h2 className="conteudoPrincipal-cadastro-titulo">Cadastro de Tipo de Chamado</h2> */}

                        {/* Formulário de cadastro de Tipo de Chamado */}
                        <form onSubmit={this.cadastrarTipoChamado}>
                            <div className="container">
                                <input 
                                    type="text"
                                    id="nome-tipo-chamado"
                                    value={this.state.titulo}
                                    onChange={this.atualizaEstadoTitulo}
                                    placeholder="Título do Tipo de Chamado"
                                />

                                {/* Altera o texto do botão de acordo com a operação ( edição ou cadastro ) usando if ternário */}

                                {/* {
                                    this.state.idTipoChamadoAlterado === 0 ?
                                    <button type="submit">Cadastrar</button> :
                                    <button type="submit">Editar</button>
                                } */}

                                {/* Uma outra forma, com if ternário e disabled ao mesmo tempo */}

                                {
                                    <button className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro" type="submit" disabled={this.state.titulo === '' ? 'none' : ''} >
                                        {this.state.idTipoChamadoAlterado === 0 ? 'Cadastrar' : 'Atualizar'}
                                    </button>
                                }

                                {/* Faz a chamada da função limparCampos */}
                                
                                <button className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro" type="button" onClick={this.limparCampos}>
                                    Cancelar
                                </button>

                                {/* 
                                    Caso algum Tipo de Evento tenha sido selecionado para edição,
                                    exibe a mensagem de feedback ao usuário
                                */}

                                {
                                    this.state.idTipoChamadoAlterado !== 0 &&
                                    <div>
                                        <p>O tipo de Chamado <strong>{this.state.idTipoChamadoAlterado}</strong> está sendo editado </p>
                                        <p>Pressione o botão Cancelar caso queira abortar a operação antes de cadastrar um novo tipo de Chamado</p>
                                    </div>
                                }

                            </div>
                        </form>
                    </section>
                </main>

                <Rodape />
            </div>
        )
    }
}

export default TiposChamados;