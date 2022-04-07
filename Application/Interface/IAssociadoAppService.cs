using Application.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IServicosAssociadoAppService
    {

        long PostCadastroServicosAssociado(PostServicosAssociadoViewModel postServicosAssociadoView);

        long GetCadastroServicosAssociado(long id);
    }
}
