using System;
using System.Collections.Generic;

namespace Implementeringsprojekt {
    public class CustomTuple<type1, type2> {
        public type1 Item1 { get; set; }
        public type2 Item2 { get; set; }

        public CustomTuple(type1 _Item1, type2 _Item2) {
            Item1 = _Item1;
            Item2 = _Item2;
        }
    }
    
    public class Hashtable {
        private int l;
        private UInt64 size;
        private List<CustomTuple<UInt64, int>>[] hashtable;
        private Func<ulong, int, UInt64> hashFunction;

        public Hashtable(int _l, Func<ulong, int, UInt64> _hashFunction) {
            l = _l;
            size = (UInt64) Math.Pow(2, l);
            hashtable = new List<CustomTuple<UInt64, int>>[size];
            hashFunction = _hashFunction;
        }
        
        public int get ( ulong key ) {
            UInt64 index = hashFunction(key, l);
            List<CustomTuple<UInt64, int>> list = hashtable[index];
            if ( list == null ) {
                return 0;
            }
            CustomTuple<UInt64, int> found = list.Find(x => x.Item1 == key);
            return found.Item2;
        }

        public void set(ulong key, int value) {
            UInt64 index = hashFunction(key, l);
            List<CustomTuple<ulong, int>> list  = hashtable[index];
            if ( list == null ) {
                list = new List<CustomTuple<ulong, int>>();
                list.Add(new CustomTuple<ulong, int>(key, value));
            } else {
                bool changed = false;
                foreach (CustomTuple<ulong, int> keyValue in list) {
                    if ( keyValue.Item1 == key ) {
                        keyValue.Item2 = value;
                        changed = true;
                        break;
                    }
                }

                if (!changed) {
                    list.Add(new CustomTuple<ulong, int>(key, value));
                }
            }
        }

        public void increment(ulong key, int d) {
            UInt64 index = hashFunction(key, l);
            List<CustomTuple<ulong, int>> list  = hashtable[index];
            if ( list == null ) {
                list = new List<CustomTuple<ulong, int>>();
                list.Add(new CustomTuple<ulong, int>(key, d));
            } else {
                bool changed = false;
                foreach (CustomTuple<ulong, int> keyValue in list) {
                    if ( keyValue.Item1 == key ) {
                        keyValue.Item2 += d;
                        changed = true;
                        break;
                    }
                }

                if (!changed) {
                    list.Add(new CustomTuple<ulong, int>(key, d));
                }
            }
        }
    }
}