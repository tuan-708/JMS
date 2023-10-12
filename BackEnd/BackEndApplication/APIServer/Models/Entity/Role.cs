using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace APIServer.Models.Entity
{
    public enum Role
    {
        Admin,
        User,
        Manager,
    }
}