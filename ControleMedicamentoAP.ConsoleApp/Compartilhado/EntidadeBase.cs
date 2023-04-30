using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentoAP.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {

        public int id;

        public abstract void AtualizarInformações(EntidadeBase registroAtualizado);
    }
}
