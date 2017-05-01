using System;

namespace Interfaces
{
    public interface ICheckable
    {
        void Set_checksum(byte checksum, string filename);
        bool Check_checksum(byte checksum, string filename);
        byte Get_checksum(string filename);
    }
}
