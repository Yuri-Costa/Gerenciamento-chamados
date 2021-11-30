import { React, Component } from 'react';
import axios from 'axios';
import "../../assets/css/style.css";
import "../../assets/css/eventos.css";
import { Link } from 'react-router-dom';
import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";
import logo from "../../assets/img/logo.png";




export default class Eventos extends Component {
    constructor(props){
        super(props);
        this.state = {
            titulo : '',
            descricao : '',
            dataEvento : new Date(),
            acessoLivre : 0,
            idTipoEvento : 0,
            idInstituicao : 0,
            listaTiposEventos : [],
            listaInstituicoes : [],
            listaEventos : [],
            isLoading : false
        }
    };

    // Função responsável por fazer a requisição e trazer a lista de tipos eventos
    buscarTiposEventos = () => {
        // Faz a chamada para a API usando o axios
        axios('http://localhost:5000/api/tiposeventos', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            // Caso a requisição retorne um status code 200
            if (resposta.status === 200) {
                // atualiza o state listaTiposEventos com os dados obtidos
                this.setState({ listaTiposEventos : resposta.data })
                // e mostra no console do navegador a lista de tipos eventos
                console.log(this.state.listaTiposEventos)
            }
        })
        // Caso ocorra algum erro, mostra no console do navegador
        .catch(erro => console.log(erro));
    };

    // Função responsável por fazer a requisição e trazer a lista de instituições
    buscarInstituicoes = () => {
        // Faz a chamada para a API usando o axios
        axios('http://localhost:5000/api/instituicoes', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            // Caso a requisição retorne um status code 200
            if (resposta.status === 200) {
                // atualiza o state listaInstituicoes com os dados obtidos
                this.setState({ listaInstituicoes : resposta.data })
                // e mostra no console do navegador a lista de instituições
                console.log(this.state.listaInstituicoes)
            }
        })
        // Caso ocorra algum erro, mostra no console do navegador
        .catch(erro => console.log(erro));
    };

    // Função responsável por fazer a requisição e trazer a lista de eventos
    buscarEventos = () => {
        // Faz a chamada para a API usando o axios
        axios('http://localhost:5000/api/eventos', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            // Caso a requisição retorne um status code 200
            if (resposta.status === 200) {
                // atualiza o state listaEventos com os dados obtidos
                this.setState({ listaEventos : resposta.data })
                // e mostra no console do navegador a lista de eventos
                console.log(this.state.listaEventos)
            }
        })
        // Caso ocorra algum erro, mostra no console do navegador
        .catch(erro => console.log(erro));
    };

    // Chama as funções assim que a tela é renderizada
    componentDidMount(){
        this.buscarTiposEventos();
        this.buscarInstituicoes();
        this.buscarEventos();
    };

    // Função que faz a chamada para a API para cadastrar um evento
    cadastrarEvento = (event) => {
        // Ignora o comportamento padrão do navegador
        event.preventDefault();
        // Define que a requisição está em andamento
        this.setState({ isLoading : true })

        // Define um evento que recebe os dados do state
        // É necessário converter o acessoLivre para int, para que o back-end consiga converter para bool ao cadastrar
        // Como o navegador envia o dado como string, não é possível converter para bool implicitamente
        let evento = {
            nomeEvento : this.state.titulo,
            descricao : this.state.descricao,
            dataEvento : new Date( this.state.dataEvento ),
            acessoLivre : parseInt( this.state.acessoLivre ),
            idTipoEvento : this.state.idTipoEvento,
            idInstituicao : this.state.idInstituicao
        };

        // Define a URL e o corpo da requisição
        axios.post('http://localhost:5000/api/eventos', evento, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        // Verifica o retorno da requisição
        .then(resposta => {
            // Caso retorne status code 200,
            if (resposta.status === 201) {
                // exibe no console do navegador a mensagem abaixo
                console.log('Evento cadastrado!')
                // e define que a requisição terminou
                this.setState({ isLoading : false })
            }
        })

        // Caso haja algum erro, exibe este erro no console do navegador
        .catch(erro => {
            console.log(erro);
            // e define que a requisição terminou
            this.setState({ isLoading : false });
        })

        // Então, atualiza a lista de Eventos
        // sem o usuário precisar executar outra ação
        .then(this.buscarEventos)
    };

    // Função genérica que atualiza o state de acordo com o input
    // pode ser reutilizada em vários inputs diferentes
    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(

            <>
            <div>
                <main>
                    <section>
                        
                        {/* Lista de Eventos */}
                        <header className="cabecalhoPrincipal">
        <div className="container">
          <Link to="/"><img src={logo} alt="logo da Gufi" /></Link>

          <nav className="cabecalhoPrincipal-nav">
            <Link to="/">Home</Link>
            <Link to="eventos">Chamados</Link>
            <a href="#conteudoPrincipal-contato">Contato</a>
            <Link className="cabecalhoPrincipal-nav-login" to="login" >Login</Link>
            {/* <a className="cabecalhoPrincipal-nav-login" href="login">Login</a> */}
          </nav>
        </div>
      </header>
                        <h2 className = "listaChamados">Chamados</h2>
                        <table style={{ borderCollapse : 'separate', borderSpacing : 30 }}>
                            <thead>
                                <tr>
                                    <th>Nome do Requerente</th>
                                    <th>Descrição do chamado</th>
                                    <th>Data</th>
                                    <th>status</th>
                                    <th>Tipo de chamado</th>
                                    
                                </tr>
                            </thead>

                            <tbody>
                                {/* Preenche o corpo da tabela usando a função map() */}

                                {
                                    this.state.listaEventos.map( evento => {
                                        return(
                                            <tr key={evento.idEvento}>
                                                <td>{evento.idEvento}</td>
                                                <td>{evento.nomeEvento}</td>
                                                <td>{evento.descricao}</td>
                                                <td>{Intl.DateTimeFormat("pt-BR").format(new Date(evento.dataEvento))}</td>

                                                {/* 
                                                
                                                    ESTRUTURA IF TERNÁRIO
                                                    CONDIÇÃO ? CASO TRUE : CASO FALSE
                                                
                                                */}

                                                <td>{evento.acessoLivre ? 'urgente' : 'não urgente'}</td>
                                                <td>{evento.idTipoEventoNavigation.tituloTipoEvento}</td>
                                                <td>{evento.idInstituicaoNavigation.nomeFantasia}</td>
                                            </tr>
                                        );
                                    } )
                                }
                            </tbody>
                        </table>
                    </section>

                    <section>
                        {/* Cadastro de Eventos */}
                        <h2>fazer chamado</h2>
                        {/* Faz a chamada para a função de cadastro quando botão é pressionado */}
                        <form onSubmit={this.cadastrarEvento}>
                            <div style={{ display : 'flex', flexDirection : 'column', width : '30vw' }}>

                                <input 
                                    // Título
                                    type="text"
                                    name="titulo"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.titulo}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Nome do Requerente"
                                />

                                <input 
                                    required
                                    // Descrição
                                    type="text"
                                    name="descricao"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.descricao}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Descrição do chamado"
                                />

                                <input 
                                    // Data do evento
                                    type="date"
                                    name="dataEvento"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.dataEvento}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                />

                                <select
                                    // Acesso Livre
                                    name="acessoLivre"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.acessoLivre}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                >
                                    <option value="1">urgente</option>
                                    <option value="0">não urgente</option>
                                </select>

                                <select
                                    // Tipo de Evento
                                    name="idTipoEvento"
                                    // Define que o valor do input é o valor do state
                                    value={this.state.idTipoEvento}
                                    // Chama a função para atualizar o state cada vez que há alteração no input
                                    onChange={this.atualizaStateCampo}
                                >
                                    <option value="0">-selecione o chamado-</option>
                                    <option value="1">Manutenção</option>
                                    <option value="2">Recepção</option>
                                    <option value="3">Segurança</option>
                                    <option value="4">Limpeza</option>

                                    {/* Utiliza a função map() para preencher a lista de opções */}

                                    {
                                        // Percorre a lista de Tipos Eentos e retorna uma opção para cada tema
                                        // definindo o valor como o seu próprio ID

                                        this.state.listaTiposEventos.map( tema => {
                                            return(
                                                <option key={tema.idTipoEvento} value={tema.idTipoEvento}>
                                                    {tema.tituloTipoEvento}
                                                </option>
                                            );
                                        } )
                                    }
                                </select>

                               
                           

                                {/* Verifica se alguma requisição está em andamento, através do valor do state isLoading */}

                                {
                                    // Caso seja true, renderiza um botão desabilitado com o texto 'Loading...'
                                    this.state.isLoading === true &&
                                    <button type="submit" disabled>
                                        Loading...
                                    </button>
                                }

                                {
                                    // Caso seja false, renderiza um botão habilitado com o texto 'Cadastrar'
                                    this.state.isLoading === false &&
                                    <button type="submit">
                                        Fazer chamado
                                    </button>
                                }

                            </div>
                        </form>
                    </section>
                </main>

            </div>
            </>
        );
    };
};