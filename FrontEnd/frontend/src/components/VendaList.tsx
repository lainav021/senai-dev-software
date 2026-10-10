import type { Venda } from '../types/Venda'

// Dados que o componente PAI precisa fornecer
interface Props {
  vendas: Venda[]
  loading: boolean
}

function VendaList({ vendas, loading }: Props) {

  if (loading)
    return <p>Carregando...</p>

  if (vendas.length === 0)
    return <p>Nenhuma venda cadastrada ainda.</p>

  return (
    <ul>
      {vendas.map(v => (
        <li key={v.id}>
          <strong>Venda{v.id}</strong>
          {' — '}
          Cliente: {v.clienteId}
          {' — '}
          Produto: {v.produtoId}
          {' — '}
          Quantidade: {v.quantidade}
          {' — '}
          R$ {v.valor_total.toFixed(2)}
        </li>
      ))}
    </ul>
  )
}

export default VendaList