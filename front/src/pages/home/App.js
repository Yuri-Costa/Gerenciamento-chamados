import { Link } from 'react-router-dom';

import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";

import logo from "../../assets/img/logo.png";

import Rodape from '../../components/rodape/rodape';

function App() {
  return (
    <div>
      <header className="cabecalhoPrincipal">
        <div className="container">
          <Link to="/"><img src={logo} alt="logo Chamado" /></Link>

          <nav className="cabecalhoPrincipal-nav">
            <Link to="/">Home</Link>
            <Link to="eventos">Chamados</Link>
            <a href="#conteudoPrincipal-contato">Contato</a>
            <Link className="cabecalhoPrincipal-nav-login" to="login" >Login</Link>
            {/* <a className="cabecalhoPrincipal-nav-login" href="login">Login</a> */}
          </nav>
        </div>
      </header>

      <section className="conteudoImagem">
        <div>
          <h1>Chamados</h1>
          <h2>Sistema de gerenciamento de Chamados</h2>
        </div>
      </section>

      <main className="conteudoPrincipal">
        <section id="conteudoPrincipal-chamado">
          <h1 id="conteudoPrincipal-chamados-titulo">Fazer chamados</h1>
          <div className="container">
            <nav>
              <ul className="conteudoPrincipal-dados">
                <li className="conteudoPrincipal-dados-link eventos">
                  <h2>Segurança</h2>
                  <p>
                    clique para realizar um chamado para a equipe de segurança.
                  </p>
                  <button>conectar</button>
                </li>

                <li className="conteudoPrincipal-dados-link chamados">
                  <h2>recepção</h2>
                  <p>
                  clique para realizar um chamado para a recepção.
                  </p>
                  <button>conectar</button>
                </li>

                <li className="conteudoPrincipal-dados-link chamados">
                  <h2>limpeza</h2>
                  <p>
                  clique para realizar um chamado para a equipe de limpeza.
                  </p>
                  <button>conectar</button>
                </li>

                <li className="conteudoPrincipal-dados-link eventos">
                  <h2>Manutenção</h2>
                  <p>
                  clique para realizar um chamado para a equipe de manutenção.
                  </p>
                  <button>conectar</button>
                </li>
              </ul>
            </nav>
          </div>
        </section>

        <section id="conteudoPrincipal-visao">
          <h1 id="conteudoPrincipal-visao-titulo">Gerenciamento de chamados</h1>
          <div className="container">
            <p className="visao-texto">
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. <br />
              Nullam auctor suscipit eros sed blandit. <br />
              Fusce euismod neque sed dapibus sollicitudin. <br />Duis vel lacus
              vestibulum, molestie dui eu, bibendum nunc.
            </p>
          </div>
        </section>

        <section id="conteudoPrincipal-contato">
          <h1 id="conteudoPrincipal-contato-titulo">Contato</h1>
          <div
            className="container conteudo-contato-titulo"
          >
            <div
              className="contato-mapa conteudo-contato-mapa"
            ></div>
            <div
              className="contato-endereco conteudo-contato-endereco"
            >
              (11) 4002-8922 <br />
              São Paulo - SP
            </div>
          </div>
        </section>
      </main>
      
      <Rodape />

    </div>
  );
}

export default App;
