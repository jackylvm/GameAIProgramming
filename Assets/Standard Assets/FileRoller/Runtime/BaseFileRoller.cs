﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MS.FileRoller
{
    public abstract class BaseFileRoller<TFileInfo>
    {
        private class FileMatchResult
        {
            public string path;
            public TFileInfo fileInfo;
            public Match match;
        }

        public readonly int maxNumOfBackups;
        public readonly string dir;
        public readonly string fileNamePattern;

        public BaseFileRoller(string dir, string fileNamePattern, int maxNumOfBackups)
        {
            this.dir = dir;
            this.fileNamePattern = fileNamePattern;
            this.maxNumOfBackups = maxNumOfBackups;
        }

        protected abstract int CompareFile(TFileInfo f1, TFileInfo f2);
        protected abstract string ResolveRollName(TFileInfo f);
        protected abstract TFileInfo ExtractFileInfo(Match match);

        private List<FileMatchResult> ListFiles()
        {
            var regex = new Regex(fileNamePattern);
            var list = Directory.GetFiles(dir).Select((filePath) =>
            {
                string fileName = Path.GetFileName(filePath);
                var match = regex.Match(fileName);
                return new FileMatchResult()
                {
                    path = filePath,
                    match = match,
                };
            }).Where((result) => { return result.match.Success; }).ToList();

            foreach (var i in list)
            {
                i.fileInfo = ExtractFileInfo(i.match);
            }

            return list;
        }

        private void EnsureDir()
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }


        public void Roll()
        {
            EnsureDir();
            var fileMatches = ListFiles();
            //after sort, newer file, fronter
            fileMatches.Sort((f1, f2) => { return CompareFile(f1.fileInfo, f2.fileInfo); });
            //delete files until rest count is <options.maxNumOfBackups>
            while (fileMatches.Count > maxNumOfBackups)
            {
                var lastFile = fileMatches[fileMatches.Count - 1];
                fileMatches.RemoveAt(fileMatches.Count - 1);
                File.Delete(lastFile.path);
            }

            if (fileMatches.Count == 0)
            {
                return;
            }

            List<string> pathChain = new List<string>();
            var index = 0;
            while (true)
            {
                var fileMatchInfo = fileMatches[index];
                var path = fileMatchInfo.path;
                pathChain.Add(path);
                var rollToPath = ResolveRollName(fileMatchInfo.fileInfo);
                if (rollToPath == null)
                {
                    break;
                }

                if (index >= fileMatches.Count - 1)
                {
                    pathChain.Add(rollToPath);
                    break;
                }

                if (fileMatches[index + 1].path != rollToPath)
                {
                    pathChain.Add(rollToPath);
                    break;
                }

                index++;
            }

            //start roll
            for (var i = pathChain.Count - 2; i >= 0; i--)
            {
                var srcPath = pathChain[i];
                var dstPath = pathChain[i + 1];
                File.Move(srcPath, dstPath);
            }
        }
    }
}