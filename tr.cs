using System.Runtime.InteropServices;
//don't forget to add <AllowUnsafeBlocks>true</AllowUnsafeBlocks> to csproj
unsafe int ri(int min, int max)
{
    IntPtr allocatedMemory = Marshal.AllocHGlobal(sizeof(int));
    IntPtr pv = allocatedMemory;
    Marshal.FreeHGlobal(pv);
    int v = ((*(int*)pv) % (max - min)) + min;
    return v<0&&!(min<0)?-v:v;
}
unsafe List<int> ril(int min, int max, int c) //random number from memory trash
{
    List<IntPtr> allocatedMemory = new List<IntPtr>();
    for (int i = 0; i < c; i++) allocatedMemory.Add(Marshal.AllocHGlobal(sizeof(int)));
    List<int> r = new List<int>();
    for (int i = 0; i < c; i++)
    {
        IntPtr pv = allocatedMemory[i];
        Marshal.FreeHGlobal(pv);
        int v = ((*(int*)pv) % (max - min)) + min;
        if (v<0 && !(min<0))
            v*=-1;
        //System.Console.WriteLine(v);
        r.Add(v);
    }
    return r;
}
