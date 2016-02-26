using System;
using System.Collections.Generic;
using System.Web;

namespace WebSite.Helpers
{
    public abstract class Upload
    {
        public static List<byte[]> SingleUpload(HttpFileCollectionBase files)
        {
            if (files == null)
            {
                throw new ArgumentException("Não foram encontrados arquivos para upload.");
            }

            var lista = new List<byte[]>();

            for (var i = 0; i < files.Count; i++ )
            {
                var arquivo = files[i];
                var bytes = new byte[arquivo.ContentLength + 1];
                arquivo.InputStream.Read(bytes, 0, bytes.Length + 1);

                lista.Add(bytes);
            }
            return lista;
        }
    }
}