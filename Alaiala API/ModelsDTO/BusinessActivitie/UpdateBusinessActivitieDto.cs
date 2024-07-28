using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.ModelsDTO.BusinessActivitie
{
    public class UpdateBusinessActivitieDto
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
    }
}
