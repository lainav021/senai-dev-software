import { useEffect, useState } from 'react'
import type { Venda } from '../types/Venda'
import { vendaService } from '../services/vendaService'
import VendaForm from '../components/VendaForm'
import VendaList from '../components/VendaList'

function VendasPage() {
  const [vendas, setVendas] = useState<Venda[]>([])
  const [loading, setLoading] = useState(false)
  const [erro, setErro] = useState<string | null>(null)

  const carregarVendas = async () => {
    try {
      setLoading(true)
      setVendas(await vendaService.listar())
    } catch { setErro('Erro ao carregar venda.') }
    finally { setLoading(false) }
  }

  useEffect(() => { carregarVendas() }, [])

  return (<div>
    <h1>Gestão de Vendas</h1>
    <VendaForm onVendaCriada={carregarVendas} />
    {erro && <p>{erro}</p>}
    <VendaList vendas={vendas} loading={loading} />
  </div>)
}
export default VendasPage