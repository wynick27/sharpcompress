﻿using System.IO;
using SharpCompress.Common;
using SharpCompress.Common.Rar;

namespace SharpCompress.Readers.Rar
{
    internal class SingleVolumeRarReader : RarReader
    {
        private readonly Stream stream;

        internal SingleVolumeRarReader(Stream stream, string password, Options options)
            : base(options)
        {
            Password = password;
            this.stream = stream;
        }

        internal override void ValidateArchive(RarVolume archive)
        {
            if (archive.IsMultiVolume)
            {
                throw new MultiVolumeExtractionException(
                                                         "Streamed archive is a Multi-volume archive.  Use different RarReader method to extract.");
            }
        }

        internal override Stream RequestInitialStream()
        {
            return stream;
        }
    }
}