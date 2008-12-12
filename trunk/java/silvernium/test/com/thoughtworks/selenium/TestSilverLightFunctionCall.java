package com.thoughtworks.selenium;

import static org.easymock.EasyMock.createMock;
import static org.easymock.EasyMock.expect;
import static org.easymock.EasyMock.replay;
import static org.easymock.EasyMock.verify;
import junit.framework.TestCase;

/*
 * Test Silvernium calls to the any function 
 * on a SilverLight object
 * 
 * Functions must be "Scriptable" 
 * by the SilverLight component in order to be successfully called.
 * 
 */
public class TestSilverLightFunctionCall extends TestCase {

	private Silvernium silverLightApp;
	private Selenium selenium;

	private static final String SILVER_OBJ_ID = "SilverLight_OBJ_ID";
	private static final String FUNCTION = "FUNCTION";
	private static final String PARAM1 = "PARAM1";
	private static final String PARAM2 = "PARAM2";
	private static final String RETURN_VALUE = "RETURN_VALUE";
	
	private String asxObj;
	
	public void setUp() {
		selenium = createMock(Selenium.class);
		silverLightApp = Silvernium.createSilverLightObjAsWindowDocument(selenium, SILVER_OBJ_ID);
		asxObj = silverLightApp.silverLightJSStringPrefix();
	}

	public void tearDown() {
		selenium = null;
		silverLightApp = null;
	}
	
	public void testCallFunctionShouldCallJSWithSeleniumGetEval() {
		String expectedEvalArg = asxObj + "content.FUNCTION('PARAM1','PARAM2');";
		expect(selenium.getEval(expectedEvalArg)).andReturn(RETURN_VALUE);
		replay(selenium);
		assertEquals(RETURN_VALUE, silverLightApp.call(FUNCTION, PARAM1, PARAM2));
		verify(selenium);
	}		
	

}
