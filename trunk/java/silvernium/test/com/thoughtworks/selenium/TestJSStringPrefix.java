package com.thoughtworks.selenium;

import junit.framework.TestCase;

/*
 * Tests the JS string to be passed to Selenium GetEval()
 * 
 */
public class TestJSStringPrefix extends TestCase {

	private Silvernium silverLightApp;

	private static final String SILVER_OBJ_ID = "SILVERLIGHT_OBJ_ID";
	private static final String FUNCTION = "FUNCTION";
	private static final String PARAM1 = "PARAM1";
	private static final String PARAM2 = "PARAM2";
	
	private String silverLightMovieObj;
	
	public void setUp() {
		silverLightApp = Silvernium.createSilverLightObjAsWindowDocument(null, SILVER_OBJ_ID);
		silverLightMovieObj = silverLightApp.silverLightJSStringPrefix();
	}

	public void tearDown() {
		silverLightApp = null;
	}
	
	public void testSilverLightJSStringPrefixFunctionWithoutParameters() {
		assertEquals(silverLightMovieObj + "FUNCTION();", silverLightApp.jsForDirectMethod("FUNCTION"));
	}

	public void testSilverLightJSStringPrefixFunctionWithOneParameter() {
		assertEquals(silverLightMovieObj + "FUNCTION('PARAM1');", silverLightApp.jsForDirectMethod(FUNCTION, PARAM1));
	}
	
	public void testSilverLightJSStringPrefixFunctionWithSeveralParameters() {
		assertEquals(silverLightMovieObj + "FUNCTION('PARAM1','PARAM2');", silverLightApp.jsForDirectMethod(FUNCTION, PARAM1, PARAM2));
	}	

}
