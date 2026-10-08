import { useState } from 'react'
import { NavLink } from 'react-router-dom'

export default function Sidebar() {
  const [aberto, setAberto] = useState(false)

  return (
    <>
      {/* Botão das 3 barras */}
      <button
        className="menu-toggle"
        onClick={() => setAberto(true)}
        aria-label="Abrir menu"
      >
        <span></span>
        <span></span>
        <span></span>
      </button>

      {/* Fundo escuro ao abrir o menu */}
      {aberto && (
        <div
          className="sidebar-overlay"
          onClick={() => setAberto(false)}
        />
      )}

      {/* Sidebar */}
      <aside className={`sidebar ${aberto ? 'sidebar-open' : ''}`}>

        <div className="sidebar-header">
          <div className="brand">
            <div className="brand-icon">M</div>
            <span>MinhaApp</span>
          </div>

          <button
            className="sidebar-close"
            onClick={() => setAberto(false)}
            aria-label="Fechar menu"
          >
            ×
          </button>
        </div>

        <div className="sidebar-menu">
          <span className="sidebar-section-title">
            NAVEGAÇÃO
          </span>

          <NavLink
            to="/produtos"
            onClick={() => setAberto(false)}
            className={({ isActive }) =>
              `sidebar-link ${isActive ? 'active' : ''}`
            }
          >
            <svg viewBox="0 0 24 24">
              <path d="M4 5h16v14H4z" />
              <path d="M8 9h8" />
              <path d="M8 13h5" />
            </svg>

            <span>Produtos</span>
          </NavLink>

          <NavLink
            to="/clientes"
            onClick={() => setAberto(false)}
            className={({ isActive }) =>
              `sidebar-link ${isActive ? 'active' : ''}`
            }
          >
            <svg viewBox="0 0 24 24">
              <circle cx="12" cy="8" r="3" />
              <path d="M5 19c.8-3 3.1-4.5 7-4.5s6.2 1.5 7 4.5" />
            </svg>

            <span>Clientes</span>
          </NavLink>
        </div>

        <div className="sidebar-footer">
          <span className="status-dot"></span>
          <span>Sistema online</span>
        </div>

      </aside>
    </>
  )
}