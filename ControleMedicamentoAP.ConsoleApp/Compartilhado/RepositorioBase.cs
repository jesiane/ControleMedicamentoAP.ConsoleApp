using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentoAP.ConsoleApp.Compartilhado
{
    public abstract class RepositorioBase
    {
        protected ArrayList listaRegistros;
        protected int contadorRegistros = 0;

        public virtual void Inserir(EntidadeBase resgistro)
        {
            contadorRegistros++;

            resgistro.id = contadorRegistros;
            
            listaRegistros.Add(resgistro);
        }

        public virtual void Editar(int id, EntidadeBase registroAtualizado)
        {
            EntidadeBase registroSelecionado = SelecionarPorId(id);
            registroSelecionado.AtualizarInformações(registroAtualizado);
        }
        public virtual void Excluir(int id)
        {
            EntidadeBase registroSelecionado = SelecionarPorId(id);
            listaRegistros.Remove(registroSelecionado); 
        }

        public virtual EntidadeBase SelecionarPorId(int id) {
            EntidadeBase registroSelecionado = null;
            foreach(EntidadeBase registro in listaRegistros)
            {
                if(registro.id == id)
                {
                    registroSelecionado = registro;
                    break;
                }
            }
            return registroSelecionado;
        }

        public virtual ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }
    }
}
