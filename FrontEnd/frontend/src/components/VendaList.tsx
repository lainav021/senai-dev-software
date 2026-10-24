
import type { Venda } from '../types/Venda'

interface Props {
  vendas: Venda[]
  loading: boolean
}

function VendaList({ vendas, loading }: Props) {
  if (loading) {
    return <p>Carregando...</p>
  }

  if (vendas.length === 0) {
    return <p>Nenhuma venda cadastrada ainda.</p>
  }

  return (
    <ul>
      {vendas.map(v => (
        <li key={v.id}>
          <strong>Venda {v.id}</strong>
          {' — '}
          Cliente: {v.cliente_Id}
          {' — '}
          Produto: {v.produto_Id}
          {' — '}
          Quantidade: {v.quantidade ?? 'Não informada'}
          {' — '}
          R$ {Number(v.valor ?? v.valor_total ?? 0).toFixed(2)}
        </li>
      ))}
    </ul>
  )
}

export default VendaList
