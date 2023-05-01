
using System.Collections;

namespace ControleMedicamentoAP.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {

        public int id;

        public abstract void AtualizarInformações(EntidadeBase registroAtualizado);

        public abstract ArrayList Validar();
        
    }
}
