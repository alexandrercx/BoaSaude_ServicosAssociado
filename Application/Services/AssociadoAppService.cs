using Application.Interface;
using Application.ViewModel.Request;
using System;

namespace Application.Services
{
    public class ServicosAssociadoAppService : Base, IServicosAssociadoAppService
    {
        public long GetCadastroServicosAssociado(long id)
        {
            throw new NotImplementedException();
        }

        public long PostCadastroServicosAssociado(PostServicosAssociadoViewModel postServicosAssociadoView)
        {
            return 0;
        }

        protected override void Disposing(bool disposing)
        {
            base.Disposing(disposing);
        }
    }
}
