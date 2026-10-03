export interface Produto {
  id: number
  nome: string
  preco: number
  estoque: number
  ativo: boolean
}

export type NovoProduto = Omit<Produto, 'id'>