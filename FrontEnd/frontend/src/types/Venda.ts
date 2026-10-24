
export interface Venda {
  id: number
  cliente_Id: number
  produto_Id: number
  quantidade: number
  valor: number
  valor_total: number
  data_venda: Date
}

export type NovaVenda = Omit<
  Venda,
  'id' | 'valor_total' | 'data_venda'
>
