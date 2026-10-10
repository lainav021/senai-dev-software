import { useState } from 'react'
import { vendaService } from '../services/vendaService'

interface Props {
  onVendaCriada: () => void
}

function VendaForm({ onVendaCriada }: Props) {
  const [clienteId,    setClienteId]    = useState('')
  const [produtoId,   setProdutoId]   = useState('')
  const [quantidade, setQuantidade] = useState(1)
  const [loading, setLoading] = useState(false)
  const [erro,    setErro]    = useState<string | null>(null)

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setErro(null)
    try {
      setLoading(true)
      await vendaService.criar({
        clienteId: Number (clienteId),
        produtoId: Number(produtoId),
        quantidade: Number(quantidade),
        ativo: true
      })
      setClienteId('')
    
      onVendaCriada()
    } catch {
      setErro('Erro na venda. Tente novamente.')
    } finally {
      setLoading(false)
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>Cadastrar Venda</h2>

      {erro && (
        <p style={{ color: 'red' }}>{erro}</p>
      )}

      <div>
        <label htmlFor="clienteId">ClienteId</label>
        <input
          id="clienteId"
          type="text"
          value={clienteId}
          onChange={e => setClienteId(e.target.value)}
          required
        />
      </div>

      <div>
        <label htmlFor="produtoId">ProdutoId</label>
        <input
          id="produtoId"
          type="number"
          step="0.01"
          value={produtoId}
          onChange={e => setProdutoId(e.target.value)}
          required
        />
      </div>

      <div>
        <label htmlFor="quantidade">Quantidade</label>
        <input
          id="quantidade"
          type="number"
          value={quantidade}
          onChange={e => setQuantidade(Number(e.target.value))}
          required
        />
      </div>

      <button type="submit" disabled={loading}>
        {loading ? 'Salvando...' : 'Realizar Venda'}
      </button>
    </form>
  )
}
export default VendaForm