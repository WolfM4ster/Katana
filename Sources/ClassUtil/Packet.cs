using System;
using System.Collections.Generic;
using System.Text;

namespace ClassUtil
{
    public class Packet
    {
        public string name;
        public string message;
        public Opcodes command;

        public Packet()
        {
            this.command = Opcodes.NULL;
            this.message = null;
            this.name = null;
        }

        public Packet(byte[] data)
        {
            this.command = (Opcodes)BitConverter.ToInt32(data, 0);

            int nameLength = BitConverter.ToInt32(data, 4);

            int msgLength = BitConverter.ToInt32(data, 8);

            if (nameLength > 0)
                this.name = Encoding.UTF8.GetString(data, 12, nameLength);
            else
                this.name = null;

            if (msgLength > 0)
                this.message = Encoding.UTF8.GetString(data, 12 + nameLength, msgLength);
            else
                this.message = null;
        }

        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            result.AddRange(BitConverter.GetBytes((int)command));

            if (name != null)
                result.AddRange(BitConverter.GetBytes(name.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (message != null)
                result.AddRange(BitConverter.GetBytes(message.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (name != null)
                result.AddRange(Encoding.UTF8.GetBytes(name));

            if (message != null)
                result.AddRange(Encoding.UTF8.GetBytes(message));

            return result.ToArray();
        }
    }
}
