//using Microsoft.VisualBasic.FileIO;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;

//namespace ProgramAssignWebAPI.Models.Domain
//{
//    public class FileDetails
//    {
//    }
//}


using ProgramAssignWebAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProgramAssignWebAPI.Models
{
    [Table("FileDetails")]
    public class FileDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public FileType FileType { get; set; }

        

    }
}


