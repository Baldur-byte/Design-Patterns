
//抽象类 个体与组合通用的接口
public abstract class OrganizationComponent
{
    private string name;

    public OrganizationComponent(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

    public abstract void add(OrganizationComponent organization);

    public abstract void remove(OrganizationComponent organization);

    public abstract OrganizationComponent getChild(string name);

    public abstract int getStaffCount();

    public string toString()
    {
        return name + "U+0020(" + getStaffCount() + ")";
    }
}

//组合类
public class OrganizationComposite : OrganizationComponent
{
    // 体现了组合思想
    private List<OrganizationComponent> organizations = new List<OrganizationComponent> ();

    public OrganizationComposite(string name) : base(name)
    {

    }

    public override void add(OrganizationComponent organization)
    {
        organizations.Add(organization);
    }

    public override OrganizationComponent getChild(string name)
    {
        foreach(OrganizationComponent organizationComponent in organizations)
        {
            OrganizationComponent Component = organizationComponent.getChild(name);
            if(Component != null) return Component;
        }
        return null;
    }

    public override int getStaffCount()
    {
        int count = 0;
        foreach(OrganizationComponent organizationComponent in organizations)
        {
            count += organizationComponent.getStaffCount();
        }
        return count;
    }

    public override void remove(OrganizationComponent organization)
    {
        throw new NotImplementedException();
    }
}

//叶子节点  单个对象   
//由于用户只会看到对外暴露的统一接口，因此不知道对象是叶子节点还是组合对象
public class ItemDepartment : OrganizationComponent
{
    public ItemDepartment(string name) : base(name)
    {
    }

    public override void add(OrganizationComponent organization)
    {
        throw new NotSupportedException(this.getName() + "已经是最基本部门，无法添加下属部门");
    }

    public override OrganizationComponent getChild(string name)
    {
        if(getName() == name)
        {
            return this;
        }
        return null;
    }

    public override int getStaffCount()
    {
        return 20;
    }

    public override void remove(OrganizationComponent organization)
    {
        throw new NotImplementedException();
    }
}

public class AdminDepartment : OrganizationComponent
{
    public AdminDepartment(string name) : base(name)
    {
    }

    public override void add(OrganizationComponent organization)
    {
        throw new NotSupportedException(this.getName() + "已经是最基本部门，无法添加下属部门");
    }

    public override OrganizationComponent getChild(string name)
    {
        if (getName() == name)
        {
            return this;
        }
        return null;
    }

    public override int getStaffCount()
    {
        return 20;
    }

    public override void remove(OrganizationComponent organization)
    {
        throw new NotImplementedException();
    }
}

public static class Program
{
    public static void Main()
    {
        listOrgInfo();
    }

    static OrganizationComponent constructOrganization()
    {
        //构建总部
        OrganizationComposite head = new OrganizationComposite("总公司");
        AdminDepartment headAdmin = new AdminDepartment("总公司行政部");
        ItemDepartment headIt = new ItemDepartment("总公司It部");
        head.add(headAdmin);
        head.add(headIt);

        //构建分公司
        OrganizationComposite branch1 = new OrganizationComposite("天津分公司");
        AdminDepartment branch1Admin = new AdminDepartment("天津分公司行政部");
        ItemDepartment branch1It = new ItemDepartment("天津分公司It部");
        branch1.add(branch1Admin);
        branch1.add(branch1It);

        //将分公司加入到head中
        head.add(branch1);

        return head;
    }

    static void listOrgInfo()
    {
        OrganizationComponent org = constructOrganization();
        Console.WriteLine(String.Format("{0}共有{1}名员工",
                org.getName(), org.getStaffCount()));

        OrganizationComponent subOrg = org.getChild("天津分公司行政部");
        Console.WriteLine(String.Format("{0}共有{1}名员工",
                subOrg.getName(), subOrg.getStaffCount()));
    }
}
