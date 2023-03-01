//需要被隐藏的独立功能子模块
using System.Numerics;

public class OrderSys
{
    public string getOrderNum()
    {
        Console.WriteLine("查询订单号");
        return "10010";
    }
}

public class PaymentSys
{
    private OrderSys orderSys;
    public PaymentSys(OrderSys orderSys)
    {
        this.orderSys = orderSys;
    }
    public BigInteger getOrderAccount()
    {
        Console.WriteLine($"查询订单{orderSys.getOrderNum()}支付金额");
        return 100;
    }
}

public class DeliverySys
{
    public int getDeliveryTime()
    {
        Console.WriteLine("获取订单配送耗时");
        return 10086;
    }
}

//创建外观类
public class ReportFacade
{
    public void generateReport()
    {
        OrderSys orderSys = new OrderSys();
        PaymentSys paymentSys = new PaymentSys(orderSys);
        DeliverySys deliverySys = new DeliverySys();

        Console.WriteLine("输出最终结果：");
        Console.WriteLine($"订单号：{orderSys.getOrderNum()}金额：{paymentSys.getOrderAccount()}耗时：{deliverySys.getDeliveryTime()}");
    }
}

public static class Program
{
    public static void Main()
    {
        ReportFacade reportFacade = new ReportFacade();
        reportFacade.generateReport();
    }
}