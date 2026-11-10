
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
      <aside className={`sidebar ${aberto ? 'sidebar-open' : ''}`}>
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
            to="/dashboard"
            onClick={fecharMenu}
            className={({ isActive }) =>
              `sidebar-link ${isActive ? 'active' : ''}`
            }
          >
            <span>📊</span>
            <span>Dashboard</span>
          </NavLink>

          <NavLink
            to="/produtos"
            onClick={fecharMenu}
            className={({ isActive }) =>
              `sidebar-link ${isActive ? 'active' : ''}`
            }
          >
            <span>📦</span>
            <span>Produtos</span>
          </NavLink>

          <NavLink
            to="/clientes"
            onClick={fecharMenu}
            className={({ isActive }) =>
              `sidebar-link ${isActive ? 'active' : ''}`
            }
          >
            <span>👤</span>
            <span>Clientes</span>
          </NavLink>

          <NavLink
            to="/vendas"
            onClick={fecharMenu}
            className={({ isActive }) =>
              `sidebar-link ${isActive ? 'active' : ''}`
            }
          >
            <span>🛒</span>
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
