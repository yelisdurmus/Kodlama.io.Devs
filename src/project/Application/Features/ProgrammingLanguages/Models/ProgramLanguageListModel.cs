using Application.Features.ProgramLanguages.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ProgramLanguages.Models
{
    public class ProgramLanguageListModel : BasePageableModel
    {
        public IList<ProgramLanguageListDto> Items { get; set; }
    }
}
