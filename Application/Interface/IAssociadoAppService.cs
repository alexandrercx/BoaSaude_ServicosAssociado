using Application.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IServicosAssociadoAppService
    {

        int PostCadastroServicosAssociado(PostServicosAssociadoViewModel postServicosAssociadoView);

        int GetCadastroServicosAssociado(int id);
    }
}
