package com.thoughtworks.selenium;

import com.thoughtworks.selenium.Selenium;

/*
 * The SilverLightSelenium is the component adding SilverLight 
 * communication capabilities to the Selenium framework. 
 * Basically, the Silvernium is a Selenium RC Client 
 * driver extension for helping exercise the tests 
 * against the SilverLight component.  
 **/
public class Silvernium {
	private String scriptKey = "";
	private Selenium selenium;
	private final String silverLightJSStringPrefix;

	public Silvernium(Selenium selenium, String silverLightObjectId, String scriptKey) {
		if (!scriptKey.equals("")){
			this.scriptKey = scriptKey + ".";
		}
		this.selenium = selenium;
		// verify the browser type
		String appName = selenium.getEval("navigator.userAgent");
		if (appName.contains(BrowserConstants.FIREFOX3) || appName.contains(BrowserConstants.IE)) {
			silverLightJSStringPrefix = createJSPrefix_window_document(silverLightObjectId);		
		}
		else {
			silverLightJSStringPrefix = createJSPrefix_document(silverLightObjectId);	
		}
	}
	
	public Silvernium(Selenium selenium, String silverLightObjectId) {
		this.selenium = selenium;
		// verify the browser type
		String appName = selenium.getEval("navigator.userAgent");
		if (appName.contains(BrowserConstants.FIREFOX3) || appName.contains(BrowserConstants.IE)) {
			silverLightJSStringPrefix = createJSPrefix_window_document(silverLightObjectId);		
		}
		else {
			silverLightJSStringPrefix = createJSPrefix_document(silverLightObjectId);	
		}
	}
	
	// constructor used for test purpose
	Silvernium(Selenium browser, String silverLightObjectId, String silverLightJSStringPrefix, boolean testOnly) {
		this.selenium = browser;
		this.silverLightJSStringPrefix = silverLightJSStringPrefix;
	}

	
	// creational method used for test purpose
	static Silvernium createSilverLightObjAsDocument(Selenium browser, String silverLightObjectId){
		return new Silvernium(browser, silverLightObjectId, createJSPrefix_document(silverLightObjectId), true);
	}
	
	static Silvernium createSilverLightObjAsWindowDocument(Selenium browser, String silverLightObjectId){
		return new Silvernium(browser, silverLightObjectId, createJSPrefix_window_document(silverLightObjectId), true);
	}

	static String createJSPrefix_window_document(String silverLightObjectId) {
		return "window.document['"
			+ silverLightObjectId + "'].";	
	}

	static String createJSPrefix_document(String silverLightObjectId) {
		return "document['"
			+ silverLightObjectId + "'].";
	}

	public String directMethod(String functionName, String ... args) {
		return selenium.getEval(this.jsForDirectMethod(functionName, args));
	}	

	public String contentMethod(String functionName, String ... args) {
		return selenium.getEval(this.jsForContentMethod(functionName, args));
	}	

	public String getPropertyValue(String propertyName) {
		return selenium.getEval(this.jsForContentScriptGetProperty(propertyName));
	}	
	
	public String setPropertyValue(String propertyName, String arg) {
		return selenium.getEval(this.jsForContentScriptSetProperty(propertyName, arg));
	}	
	
	public String call(String functionName, String ... args) {
		return selenium.getEval(this.jsForContentScriptMethod(functionName, args));
	}	

	public String settingsProperty(String propertyName) {
		return selenium.getEval(this.jsForSettingsProperty(propertyName));
	}	

	public String contentProperty(String propertyName) {
		return selenium.getEval(this.jsForContentProperty(propertyName));
	}	

	public String directProperty(String propertyName) {
		return selenium.getEval(this.jsForDirectProperty(propertyName));
	}	
	
	String silverLightJSStringPrefix(){
		return this.silverLightJSStringPrefix;
	}

	String jsForDirectMethod(String functionName, String ... args) {
		String functionArgs = "";
		if (args.length>0){;
	      for (int i=0;i < args.length; i++) {
	    	  functionArgs = functionArgs + "'" + args[i] + "',";
	      }
	      // remove last comma
	      functionArgs = functionArgs.substring(0, functionArgs.length() -1);
		}
		return silverLightJSStringPrefix + functionName + "(" + functionArgs + ");";
	}	

	String jsForContentScriptMethod(String functionName, String ... args) {
		String functionArgs = "";
		if (args.length>0){;
	      for (int i=0;i < args.length; i++) {
	    	  functionArgs = functionArgs + "'" + args[i] + "',";
	      }
	      // remove last comma
	      functionArgs = functionArgs.substring(0, functionArgs.length() -1);
		}
		return silverLightJSStringPrefix + "content." + scriptKey + functionName + "(" + functionArgs + ");";
	}	

	String jsForContentScriptGetProperty(String propertyName) {
		return silverLightJSStringPrefix + "content." + scriptKey + propertyName + ";";
	}	

	String jsForContentScriptSetProperty(String propertyName, String arg) {
		return silverLightJSStringPrefix + "content." + scriptKey  + propertyName + "='"+ arg + "';";
	}	

	String jsForContentMethod(String functionName, String ... args) {
		String functionArgs = "";
		if (args.length>0){;
	      for (int i=0;i < args.length; i++) {
	    	  functionArgs = functionArgs + "'" + args[i] + "',";
	      }
	      // remove last comma
	      functionArgs = functionArgs.substring(0, functionArgs.length() -1);
		}
		return silverLightJSStringPrefix + "content." + functionName + "(" + functionArgs + ");";
	}	

	String jsForSettingsProperty(String propertyName) {
		return silverLightJSStringPrefix + "settings." + propertyName + ";";
	}	

	String jsForContentProperty(String propertyName) {
		return silverLightJSStringPrefix + "content." + propertyName + ";";
	}	

	String jsForDirectProperty(String propertyName) {
		return silverLightJSStringPrefix + propertyName + ";";
	}	

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((selenium == null) ? 0 : selenium.hashCode());
		result = prime
				* result
				+ ((silverLightJSStringPrefix == null) ? 0 : silverLightJSStringPrefix
						.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		final Silvernium other = (Silvernium) obj;
		if (selenium == null) {
			if (other.selenium != null)
				return false;
		} else if (!selenium.equals(other.selenium))
			return false;
		if (silverLightJSStringPrefix == null) {
			if (other.silverLightJSStringPrefix != null)
				return false;
		} else if (!silverLightJSStringPrefix.equals(other.silverLightJSStringPrefix))
			return false;
		return true;
	}

	// new methods created for silver light
	public boolean isVersionSupported (String versionString) {
		return new Boolean(this.directMethod("isVersionSupported", versionString));
	}

	public String accessibility() {
		return this.contentProperty("accessibility");
	}


	public int actualHeight() {
		return new Integer(this.contentProperty("actualHeight"));
	}

	public int actualWidth() {
		return new Integer(this.contentProperty("actualWidth"));
	}

	public void createFromXaml(String xamlContent, String nameScope) {
		this.contentMethod("createFromXaml", xamlContent, nameScope);
	}

	public String findName(String objectName) {
		return this.contentMethod("findName", objectName);
	}

	public boolean fullScreen() {
		return new Boolean(this.contentProperty("fullScreen"));
	}

	public String initParams() {
		return this.directProperty("initParams");
	}

	public boolean isLoaded() {
		return new Boolean(this.directProperty("isLoaded"));
	}

	public String root() {
		return this.directProperty("root");
	}

	public String background() {
		return this.settingsProperty("background");
	}

	public boolean enabledFramerateCounter() {
		return new Boolean(this.settingsProperty("enabledFramerateCounter"));
	}

	public boolean enableRedrawRegions() {
		return new Boolean(this.settingsProperty("enableRedrawRegions"));
	}

	public boolean enableHtmlAccess() {
		return new Boolean(this.settingsProperty("enableHtmlAccess"));
	}

	public int maxFrameRate() {
		return new Integer(this.settingsProperty("maxFrameRate"));
	}

	public boolean windowless() {
		return new Boolean(this.settingsProperty("windowless"));
	}

	public String source() {
		return this.directProperty("source");
	}	



	
	

}
