using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcc_UI.Models
{
    public class CarrinhoModels
    {
        private List<ProdutoModels> _Itens = new List<ProdutoModels>();
        public List<ProdutoModels> Itens { get { return _Itens; } }

        public double Total { get { return _Itens.Sum(p => p.Valor * p.Quantidade); } }

        public void AddItem(ProdutoModels produto)
        {
            _Itens.Add(produto);
        }
        public void Clear()
        {
            _Itens.Clear();
        }
        public void RemoveItem(int index)
        {
            _Itens.RemoveAt(index);
        }
    }
}