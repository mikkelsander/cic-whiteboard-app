using CIC.WhiteboardApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIC.WhiteboardApp.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string AzureActiveDirectoryId { get; set; }
        public string Name { get; set; }
        public UserRole UserRole { get; set; }
    }
}
