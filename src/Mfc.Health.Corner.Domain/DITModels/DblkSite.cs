
namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkSite
    {
        public uint Id { get; set; }
        public int Parent { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public uint Lang { get; set; }
    }
}
