package md5bb6c7dc89348f354c4d24e4665369a52;


public class MultiSpinner
	extends android.widget.Spinner
	implements
		mono.android.IGCUserPeer,
		android.content.DialogInterface.OnMultiChoiceClickListener,
		android.content.DialogInterface.OnCancelListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:(Landroid/content/DialogInterface;I)V:GetOnClick_Landroid_content_DialogInterface_IHandler\n" +
			"n_performClick:()Z:GetPerformClickHandler\n" +
			"n_onClick:(Landroid/content/DialogInterface;IZ)V:GetOnClick_Landroid_content_DialogInterface_IZHandler:Android.Content.IDialogInterfaceOnMultiChoiceClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onCancel:(Landroid/content/DialogInterface;)V:GetOnCancel_Landroid_content_DialogInterface_Handler:Android.Content.IDialogInterfaceOnCancelListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("OnSoil.Code.resources.MultiSpinner, OnSoil, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MultiSpinner.class, __md_methods);
	}


	public MultiSpinner (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MultiSpinner.class)
			mono.android.TypeManager.Activate ("OnSoil.Code.resources.MultiSpinner, OnSoil, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public MultiSpinner (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MultiSpinner.class)
			mono.android.TypeManager.Activate ("OnSoil.Code.resources.MultiSpinner, OnSoil, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public MultiSpinner (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MultiSpinner.class)
			mono.android.TypeManager.Activate ("OnSoil.Code.resources.MultiSpinner, OnSoil, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public MultiSpinner (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == MultiSpinner.class)
			mono.android.TypeManager.Activate ("OnSoil.Code.resources.MultiSpinner, OnSoil, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:Android.Widget.SpinnerMode, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public MultiSpinner (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3, int p4)
	{
		super (p0, p1, p2, p3, p4);
		if (getClass () == MultiSpinner.class)
			mono.android.TypeManager.Activate ("OnSoil.Code.resources.MultiSpinner, OnSoil, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:Android.Widget.SpinnerMode, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1, p2, p3, p4 });
	}


	public MultiSpinner (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3, int p4, android.content.res.Resources.Theme p5)
	{
		super (p0, p1, p2, p3, p4, p5);
		if (getClass () == MultiSpinner.class)
			mono.android.TypeManager.Activate ("OnSoil.Code.resources.MultiSpinner, OnSoil, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:Android.Widget.SpinnerMode, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Content.Res.Resources+Theme, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1, p2, p3, p4, p5 });
	}


	public MultiSpinner (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == MultiSpinner.class)
			mono.android.TypeManager.Activate ("OnSoil.Code.resources.MultiSpinner, OnSoil, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Widget.SpinnerMode, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public void onClick (android.content.DialogInterface p0, int p1)
	{
		n_onClick (p0, p1);
	}

	private native void n_onClick (android.content.DialogInterface p0, int p1);


	public boolean performClick ()
	{
		return n_performClick ();
	}

	private native boolean n_performClick ();


	public void onClick (android.content.DialogInterface p0, int p1, boolean p2)
	{
		n_onClick (p0, p1, p2);
	}

	private native void n_onClick (android.content.DialogInterface p0, int p1, boolean p2);


	public void onCancel (android.content.DialogInterface p0)
	{
		n_onCancel (p0);
	}

	private native void n_onCancel (android.content.DialogInterface p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
