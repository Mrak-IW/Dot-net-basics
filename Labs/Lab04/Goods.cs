struct Goods
{
	public string name;
	public string providerName;
	public System.DateTime receievingDate;
	public System.DateTime expiringDate;

	public Goods(string name, string providerName, System.DateTime receiving, System.DateTime expiring)
	{
		this.name = name;
		this.providerName = providerName;
		this.receievingDate = receiving;
		this.expiringDate = expiring;
	}

	public override string ToString()
	{
		return "Товар:\t" + name + "\nПоставщик:\t" + providerName
			+ "\nПолучен:\t" + receievingDate + "\nГоден до:\t" + expiringDate;
	}

}