using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPVPAAppDes
{
    class CrossplataformFiles
    {

        IFolder directory = FileSystem.Current.LocalStorage;//Android.App.Application.Context;

        IFile FileIma;

        public void saveFilePCS(string Filename, byte[] blob)
        {
            Device.BeginInvokeOnMainThread( async () => {
                FileIma = await directory.CreateFileAsync(Filename + ".png", CreationCollisionOption.ReplaceExisting);
                using (Stream buffer = await FileIma.OpenAsync(FileAccess.ReadAndWrite))
                {
                    buffer.Write(blob, 0, blob.Length);
                }
            });
        }
    }
}
