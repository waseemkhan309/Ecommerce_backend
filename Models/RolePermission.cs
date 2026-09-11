namespace Ecommerce_backend.Models
{
    public class RolePermission : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public Permission permission { get; set; }  = new Permission();
        public Role Role { get; set; } = new Role();

    }
}
