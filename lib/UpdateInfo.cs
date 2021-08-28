using System;
using System.IO;
using System.Diagnostics;

namespace fql
{
    public delegate void DirectoryUpdate(UpdateInfo updateInfo);

    public class UpdateInfo
    {
        public string msg;

        public int current;
        public int total;

        public DateTime startDate;

        public UpdateInfo(string _msg)
        {
            Start(_msg);
        }

        public void Start(string _msg, int _total = 0)
        {
            msg = _msg;
            current = 0;
            total = _total;
            startDate = DateTime.UtcNow;
        }

        public override string ToString()
        {
            string str = msg;
            if (total > 0 && current > 0)
            {
                if (current > total)
                    current = total;

                str += $" ({current} / {total})";

                double elapsedMs = (DateTime.UtcNow - startDate).TotalMilliseconds;
                double factorComplete = (double)current / total;
                double estimateTotalMs = elapsedMs / factorComplete;
                double timeRemainingMs = estimateTotalMs - elapsedMs;
                int timeRemainingSeconds = (int)(Math.Round(timeRemainingMs / 1000));

                string elapsedSummary;
                {
                    if (timeRemainingSeconds > 1)
                    {
                        if (timeRemainingSeconds > 3600)
                            elapsedSummary = $"{(timeRemainingSeconds / 3600)} hours";
                        else if (timeRemainingSeconds > 60)
                            elapsedSummary = $"{(timeRemainingSeconds / 60)} minutes";
                        else if (timeRemainingSeconds > 0)
                            elapsedSummary = $"{timeRemainingSeconds} seconds";
                        else
                            elapsedSummary = "";

                        elapsedSummary = $"about {elapsedSummary} left";
                    }
                    else
                        elapsedSummary = "a little bit left";
                }

                str += " - " + elapsedSummary;
            }

            return str;
        }
    }
}
