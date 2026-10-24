
import { useState } from 'react'
import { NavLink } from 'react-router-dom'
import { useAuth } from '../Context/AuthContext'

export default function Sidebar() {
  const [aberto, setAberto] = useState(false)
  const { user, logout } = useAuth()

  const fecharMenu = () => setAberto(false)

  return (
    <>
      {/* Botão das 3 barras */}
      <button
        type="button"
        className="menu-toggle"
        onClick={() => setAberto(true)}
        aria-label="Abrir menu"
        aria-expanded={aberto}
      >
        <span></span>
        <span></span>
        <span></span>
      </button>

      {/* Fundo escuro */}
      {aberto && (
        <div
          className="sidebar-overlay"
          onClick={fecharMenu}
        />
      )}

      {/* Sidebar */}
      <aside
        className={`sidebar ${aberto ? 'sidebar-open' : ''}`}
      >
        <div className="sidebar-header">
          <div className="brand">
            <div className="brand-icon">M</div>
            <span>MinhaApp</span>
          </div>

          <button
            type="button"
            className="sidebar-close"
            onClick={fecharMenu}
            aria-label="Fechar menu"
          >
            ×
          </button>
        </div>

        {/* Navegação */}
        <nav className="sidebar-menu">
          <span className="sidebar-section-title">
            NAVEGAÇÃO
          </span>

          <NavLink
            to="/produtos"
            onClick={fecharMenu}
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
            onClick={fecharMenu}
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

          <NavLink
            to="/vendas"
            onClick={fecharMenu}
            className={({ isActive }) =>
              `sidebar-link ${isActive ? 'active' : ''}`
            }
          >
            <svg viewBox="0 0 24 24">
              <path d="M3 3h2l2.4 12.2a2 2 0 0 0 2 1.6h8.8a2 2 0 0 0 2-1.6L22 7H6" />
              <circle cx="10" cy="21" r="1" />
              <circle cx="18" cy="21" r="1" />
            </svg>
            <span>Vendas</span>
          </NavLink>
        </nav>

        {/* Usuário e saída */}
        <div className="sidebar-user">
          <div className="sidebar-user-info">
            <span className="sidebar-user-icon">👤</span>
            <span>{user?.nome || 'Usuário'}</span>
          </div>

          <button
            type="button"
            className="sidebar-logout"
            onClick={logout}
          >
            Sair da conta
          </button>
        </div>

        {/* Rodapé */}
        <div className="sidebar-footer">
          <span className="status-dot"></span>
          <span>Sistema online</span>
        </div>
      </aside>
    </>
  )
}
