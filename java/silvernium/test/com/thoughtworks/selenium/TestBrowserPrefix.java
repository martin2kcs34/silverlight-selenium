package com.thoughtworks.selenium;

import static org.easymock.EasyMock.createMock;
import static org.easymock.EasyMock.expect;
import static org.easymock.EasyMock.replay;
import static org.easymock.EasyMock.verify;
import junit.framework.TestCase;

/*
 * Tests the JS browser prefix formation
 *
 */
public class TestBrowserPrefix extends TestCase {

	private Silvernium silverLightApp;
	private Selenium selenium;

	private static final String SILVER_OBJ_ID = "SILVERLIGHT_OBJ_ID";
	private static final String FUNCTION = "FUNCTION";
	private static final String RETURN_VALUE = "RETURN_VALUE";
	
	
	public void setUp() {
		selenium = createMock(Selenium.class);
		silverLightApp = Silvernium.createSilverLightObjAsWindowDocument(selenium, SILVER_OBJ_ID);
	}

	public void tearDown() {
		selenium = null;
		silverLightApp = null;
	}

	public void testSilverLightSeleniumForIE() {
		expect(selenium.getEval("navigator.userAgent")).andReturn("Firefox/2.0.0.42");
		String expectedFunctionCall = Silvernium.createJSPrefix_document(SILVER_OBJ_ID) + FUNCTION + "();"; 
		expect(selenium.getEval(expectedFunctionCall)).andReturn(RETURN_VALUE);
		replay(selenium);
		silverLightApp = new Silvernium(selenium, SILVER_OBJ_ID);
		assertEquals(RETURN_VALUE, silverLightApp.directMethod(FUNCTION));
		verify(selenium);
	}	
	
	public void testSilverLightSeleniumForNonIE() {
		expect(selenium.getEval("navigator.userAgent")).andReturn("Firefox/3.0.0.1");
		String expectedFunctionCall = Silvernium.createJSPrefix_window_document(SILVER_OBJ_ID) + FUNCTION + "();"; 
		expect(selenium.getEval(expectedFunctionCall)).andReturn(RETURN_VALUE);
		replay(selenium);
		silverLightApp = new Silvernium(selenium, SILVER_OBJ_ID);
		assertEquals(RETURN_VALUE, silverLightApp.directMethod(FUNCTION));
		verify(selenium);
	}	
	

}
