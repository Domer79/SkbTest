using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using IntelliSenseHelper.Exceptions;

namespace IntelliSenseHelper
{
    public static class Extensions
    {
        public static byte[] ToByteArray(this object @object)
        {
            var formatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, @object);
                return ms.ToArray();
            }
        }

        public static byte[] ReadBytes(this Stream stream, byte[] endMark, byte[] buffer = null)
        {
            if (stream == null) 
                throw new ArgumentNullException("stream");

            if (!stream.CanRead)
                throw new DataReadImpossibleException("Поток не поддерживает чтение");

            if (!stream.CanWrite)
                throw new DataWriteImpossibleException("Поток не поддерживает запись");

            var buf = buffer ?? new byte[1024];
            var list = new List<byte>();

            int count;
            while ((count = stream.Read(buf, 0, buf.Length)) > 0)
            {
                if (count == buf.Length)
                {
                    list.AddRange(buf);
                }
                else
                {
                    var subbuf = new byte[count];
                    Array.Copy(buf, subbuf, count);
                    list.AddRange(subbuf);
                }

                if (ListIndexOf(list, endMark))
                    break;
            }

            return list.ToArray();
        }

        private static bool ListIndexOf(List<byte> list, byte[] bytes)
        {
            if (bytes.Length == 0)
                return false;

            return list.Intersect(bytes).Any();
        }
    }
}