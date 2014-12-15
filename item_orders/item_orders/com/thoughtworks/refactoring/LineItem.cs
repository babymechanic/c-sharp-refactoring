using System;

namespace com.thoughtworks.refactoring
{
public class LineItem {
	private string desc;
	private double p;
	private int qty;

	public LineItem(string desc, double p, int qty):base() {
		this.desc = desc;
		this.p = p;
		this.qty = qty;
	}

	public string GetDescription() {
		return desc;
	}

	public double GetPrice() {
		return p;
	}

	public int GetQuantity() {
		return qty;
	}

    public double TotalAmount() {
        return p * qty;
    }
    }
 }