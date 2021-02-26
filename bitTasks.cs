public static class BitTasks{

    /// num = 10010101
    /// i = 4
    public static bool GetBit(int num, int i){
        return (num & (1 << i - 1)) != 0;
    }

    public static int SetBit(int num, int i){
        return (num | (1 << i - 1));
    }    

    public static int clearBit(int num, int i){
        return (num & ~(1 << i - 1));
    }    
    public static int clearBitIThrough0(int num, int i){
        return (num & (-1 << i - 1));
    }    

    public static int clearBitMSThroughI(int num, int i){
        return (num & ~(-1 << i - 1));
    }    

    public static int updateBit(int num, int i, bool value){
        var mask = ~(1 << i - 1);
        return (num & mask) | ((value ? 1 :0) << i - 1); 
    }
}