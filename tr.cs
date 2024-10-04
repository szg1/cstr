using System.Runtime.InteropServices;
//don't forget to add <AllowUnsafeBlocks>true</AllowUnsafeBlocks> to csproj
unsafe int ri(int min, int max)
{
    IntPtr allocatedMemory = Marshal.AllocHGlobal(sizeof(int));
    IntPtr pv = allocatedMemory;
    Marshal.FreeHGlobal(pv);
    return ((*(int*)pv) % (max - min)) + min;
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
        r.Add(((*(int*)pv) % (max - min)) + min);
    }
    return r;
}
