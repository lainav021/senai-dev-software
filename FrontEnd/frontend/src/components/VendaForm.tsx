
import { useEffect, useState } from 'react'
import { clienteService } from '../services/clienteService'
import { produtoService } from '../services/ProdutoService'
import { vendaService } from '../services/vendaService'
import type { Cliente } from '../types/Cliente'
import type { Produto } from '../types/Produto'

interface Props {
  onVendaCriada: () => void
}

function VendaForm({ onVendaCriada }: Props) {
  const [clientes, setClientes] = useState<Cliente[]>([])
  const [produtos, setProdutos] = useState<Produto[]>([])
  const [cliente_Id, setClienteId] = useState('')
  const [produto_Id, setProdutoId] = useState('')
  const [quantidade, setQuantidade] = useState(1)
  const [loading, setLoading] = useState(false)
  const [carregandoDados, setCarregandoDados] = useState(true)
  const [erro, setErro] = useState<string | null>(null)

  useEffect(() => {
    const carregarDados = async () => {
      try {
        const [listaClientes, listaProdutos] = await Promise.all([
          clienteService.listar(),
          produtoService.listar()
        ])

        setClientes(listaClientes)
        setProdutos(listaProdutos)
      } catch {
        setErro('Não foi possível carregar clientes e produtos.')
      } finally {
        setCarregandoDados(false)
      }
    }

    carregarDados()
  }, [])

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setErro(null)

    if (!cliente_Id || !produto_Id) {
      setErro('Selecione um cliente e um produto.')
      return
    }

    if (quantidade < 1) {
      setErro('A quantidade deve ser pelo menos 1.')
      return
    }

    try {
      setLoading(true)

      await vendaService.criar({
        cliente_Id: Number(cliente_Id),
        produto_Id: Number(produto_Id),
        quantidade: quantidade
      })

      setClienteId('')
      setProdutoId('')
      setQuantidade(1)

      onVendaCriada()
    } catch {
      setErro('Erro na venda. Verifique os dados e tente novamente.')
    } finally {
      setLoading(false)
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>Cadastrar Venda</h2>

      {erro && <p style={{ color: 'red' }}>{erro}</p>}

      <div>
        <label htmlFor="cliente_Id">Cliente</label>
        <select
          id="cliente_Id"
          value={cliente_Id}
          onChange={e => setClienteId(e.target.value)}
          required
          disabled={carregandoDados || clientes.length === 0}
        >
          <option value="">
            {carregandoDados
              ? 'Carregando clientes...'
              : clientes.length === 0
                ? 'Nenhum cliente cadastrado'
                : 'Selecione um cliente'}
          </option>

          {clientes.map(cliente => (
            <option key={cliente.id} value={cliente.id}>
              {cliente.nome}
            </option>
          ))}
        </select>
      </div>

      <div>
        <label htmlFor="produto_Id">Produto</label>
        <select
          id="produto_Id"
          value={produto_Id}
          onChange={e => setProdutoId(e.target.value)}
          required
          disabled={carregandoDados || produtos.length === 0}
        >
          <option value="">
            {carregandoDados
              ? 'Carregando produtos...'
              : produtos.length === 0
                ? 'Nenhum produto cadastrado'
                : 'Selecione um produto'}
          </option>

          {produtos.map(produto => (
            <option key={produto.id} value={produto.id}>
              {produto.nome}
            </option>
          ))}
        </select>
      </div>

      <div>
        <label htmlFor="quantidade">Quantidade</label>
        <input
          id="quantidade"
          type="number"
          min="1"
          step="1"
          value={quantidade}
          onChange={e => setQuantidade(Number(e.target.value))}
          required
        />
      </div>

      <button
        type="submit"
        disabled={loading || carregandoDados}
      >
        {loading ? 'Salvando...' : 'Realizar Venda'}
      </button>
    </form>
  )
}

export default VendaForm