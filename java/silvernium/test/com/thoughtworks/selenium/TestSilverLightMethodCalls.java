package com.thoughtworks.selenium;

import com.thoughtworks.selenium.Selenium;

import junit.framework.TestCase;
import static org.easymock.EasyMock.*;

/*
 * Test Silvernium calls to the SilverLight Methods
 * 
 */
public class TestSilverLightMethodCalls extends TestCase {

	private Silvernium silverLightApp;
	private Selenium selenium;

	private static final String SILVER_OBJ_ID = "SILVERLIGHT_OBJ_ID";
	private static final String STR_PARAM1 = "PARAM1";
	private static final String STR_PARAM2 = "PARAM2";
	private static final String STR_RETURN_VALUE = "STR_RETURN_VALUE";
	
	private String silverLightObj;
	
	public void setUp() {
		selenium = createMock(Selenium.class);
		silverLightApp = Silvernium.createSilverLightObjAsWindowDocument(selenium, SILVER_OBJ_ID);
		silverLightObj = silverLightApp.silverLightJSStringPrefix();
	}

	public void tearDown() {
		selenium = null;
		silverLightApp = null;
	}

//	content.accessibility
//	Accessibility information of the Silverlight content (read-only)
	public void testPropertyAccessibilityShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "content.accessibility;";
		expect(selenium.getEval(expectedEvalArg)).andReturn(STR_RETURN_VALUE);
		replay(selenium);
		assertEquals(STR_RETURN_VALUE, silverLightApp.accessibility());
		verify(selenium);
	}
	
//	content.actualHeight
//	The height of the Silverlight content (read-only)
	public void testPropertyActualHeightShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "content.actualHeight;";
		expect(selenium.getEval(expectedEvalArg)).andReturn("20");
		replay(selenium);
		assertEquals(20, silverLightApp.actualHeight());
		verify(selenium);
	}
	
//	content.actualWidth
//	The width of the Silverlight content (read-only)
	public void testPropertyActualWidthShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "content.actualWidth;";
		expect(selenium.getEval(expectedEvalArg)).andReturn("10");
		replay(selenium);
		assertEquals(10, silverLightApp.actualWidth());
		verify(selenium);
	}
	
//	content.createFromXaml(xamlContent, nameScope)
//	Creates a Silverlight object with the given XAML content; if nameScope is set to true, a unique x:Name attribute is assigned.
	public void testMethodCreateFromXamlShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "content.createFromXaml('" 
													+ STR_PARAM1 
													+ "','" 
													+ STR_PARAM2 
													+ "');";
		expect(selenium.getEval(expectedEvalArg)).andReturn(STR_RETURN_VALUE);
		replay(selenium);
		silverLightApp.createFromXaml(STR_PARAM1, STR_PARAM2);
		verify(selenium);
	}

//	content.findName(objectName)
//	Returns a reference to the object with the given name
	public void testMethodFindNameShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "content.findName('" 
												+ STR_PARAM1 
												+ "');";
		expect(selenium.getEval(expectedEvalArg)).andReturn(STR_RETURN_VALUE);
		replay(selenium);
		assertEquals(STR_RETURN_VALUE, silverLightApp.findName(STR_PARAM1));
		verify(selenium);
	}
	
//	content.fullScreen
//	Whether the Silverlight plug-in is in full-screen mode (read and write)
	public void testPropertyFullScreenShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "content.fullScreen;";
		expect(selenium.getEval(expectedEvalArg)).andReturn("true");
		replay(selenium);
		assertTrue(silverLightApp.fullScreen());
		verify(selenium);
	}
	
	
//	initParams
//	The initialization parameters provided for the Silverlight content (read-only after the initialization)
	public void testPropertyInitParamsShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "initParams;";
		expect(selenium.getEval(expectedEvalArg)).andReturn(STR_RETURN_VALUE);
		replay(selenium);
		assertEquals(STR_RETURN_VALUE, silverLightApp.initParams());
		verify(selenium);
	}	
	
//	isLoaded
//	Whether the Silverlight plug-in and its XAML content are fully loaded (read-only)
	public void testPropertyIsLoadedShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "isLoaded;";
		expect(selenium.getEval(expectedEvalArg)).andReturn("true");
		replay(selenium);
		assertTrue(silverLightApp.isLoaded());
		verify(selenium);
	}
	
//	isVersionSupported(versionString)
//	Whether the current Silverlight plug-in supports content with the given version number
	public void testMethodIsVersionSupportedShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "isVersionSupported('" 
												+ STR_PARAM1 
												+ "');";
		expect(selenium.getEval(expectedEvalArg)).andReturn("true");
		replay(selenium);
		assertTrue(silverLightApp.isVersionSupported(STR_PARAM1));
		verify(selenium);
	}
	
//	root
//	The root element of the Silverlight content (read-only)
	public void testPropertyRootShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "root;";
		expect(selenium.getEval(expectedEvalArg)).andReturn(STR_RETURN_VALUE);
		replay(selenium);
		assertEquals(STR_RETURN_VALUE, silverLightApp.root());
		verify(selenium);
	}	
	
//	settings.background
//	The background color of the Silverlight content area (read and write)
	public void testPropertyBackgroundShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "settings.background;";
		expect(selenium.getEval(expectedEvalArg)).andReturn(STR_RETURN_VALUE);
		replay(selenium);
		assertEquals(STR_RETURN_VALUE, silverLightApp.background());
		verify(selenium);
	}	
	
//	settings.enabledFramerateCounter
//	Whether the current frame rate is displayed in the browser's status bar or not (read and write; note that not all browser allow changing the content of the status bar)
	public void testPropertyEnabledFramerateCounterShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "settings.enabledFramerateCounter;";
		expect(selenium.getEval(expectedEvalArg)).andReturn("true");
		replay(selenium);
		assertTrue(silverLightApp.enabledFramerateCounter());
		verify(selenium);
	}	

//	settings.enableRedrawRegions
//	Whether the regions of the Silverlight content that are redrawn are highlighted (read and write; only useful during development)
	public void testPropertyEnableRedrawRegionsShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "settings.enableRedrawRegions;";
		expect(selenium.getEval(expectedEvalArg)).andReturn("true");
		replay(selenium);
		assertTrue(silverLightApp.enableRedrawRegions());
		verify(selenium);
	}	
	
//	settings.enableHtmlAccess
//	Whether to allow Silverlight content may access the HTML DOM (read-only)
	public void testPropertyEnableHtmlAccessShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "settings.enableHtmlAccess;";
		expect(selenium.getEval(expectedEvalArg)).andReturn("true");
		replay(selenium);
		assertTrue(silverLightApp.enableHtmlAccess());
		verify(selenium);
	}	

//	settings.maxFrameRate
//	The maximum frame rate (number of frames) of the Silverlight content (read and write)
	public void testPropertyMaxFrameRateShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "settings.maxFrameRate;";
		expect(selenium.getEval(expectedEvalArg)).andReturn("200");
		replay(selenium);
		assertEquals(200, silverLightApp.maxFrameRate());
		verify(selenium);
	}	
	
//	settings.windowless
//	Whether the Silverlight application runs in windowsless mode or not (then the background may use alphatransparency and can let the background on the HTML page shine through), set in the initialization phase (read-only afterwards)
	public void testPropertyWindowlessShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "settings.windowless;";
		expect(selenium.getEval(expectedEvalArg)).andReturn("true");
		replay(selenium);
		assertTrue(silverLightApp.windowless());
		verify(selenium);
	}	
	
//	source
//	The XAML source code of the Silverlight content (read and write)
	public void testPropertySourceShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = silverLightObj + "source;";
		expect(selenium.getEval(expectedEvalArg)).andReturn(STR_RETURN_VALUE);
		replay(selenium);
		assertEquals(STR_RETURN_VALUE, silverLightApp.source());
		verify(selenium);
	}		
	
	
	
}
