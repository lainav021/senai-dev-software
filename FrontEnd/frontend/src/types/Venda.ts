
export interface Venda {
  id: number
  cliente_Id: number
  produto_Id: number
  quantidade: number
  valor: number
  data_v: Date
}

export type NovaVenda = Omit<
  Venda,
  'id' | 'valor' | 'data_v'
>

