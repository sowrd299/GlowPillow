using System.IO;
using System.Collections.Generic;
using UnityEngine;


static class StatsReader {

    public static Dictionary<string,float[]> ReadStats(string url) {
        /*reads the given (csv) file formated:
         *      
         *      lineName,val0,val1,val2...
         *
         * and then returns the dictionary <lineNames,vals[]>
         */
        var r = new Dictionary<string, float[]>(); 
        string fileData = File.ReadAllText(url);
        foreach (string line in fileData.Split('\n')) {
            string[] lineData = line.Split(',');
            var vals = new List<float>();
            for(int i = 1; i < lineData.Length; ++i) {
                vals.Add(float.Parse(lineData[i]));
            }
            Debug.Log("Adding " + lineData[0]);
            r.Add(lineData[0], vals.ToArray());
        }
        return r;
    }

}
