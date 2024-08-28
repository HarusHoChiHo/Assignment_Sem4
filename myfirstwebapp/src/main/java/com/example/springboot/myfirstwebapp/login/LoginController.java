//package com.example.springboot.myfirstwebapp.login;
//
//import org.slf4j.Logger;
//import org.slf4j.LoggerFactory;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.stereotype.Controller;
//import org.springframework.ui.ModelMap;
//import org.springframework.web.bind.annotation.RequestMapping;
//import org.springframework.web.bind.annotation.RequestMethod;
//import org.springframework.web.bind.annotation.RequestParam;
//import org.springframework.web.bind.annotation.SessionAttributes;
//
//@Controller
//@SessionAttributes("name")
//public class LoginController {
//
//    private Logger logger = LoggerFactory.getLogger(getClass());
//
//    @Autowired
//    private AuthenticationService authenticationService;
//
//    @RequestMapping(value="login", method = RequestMethod.GET)
//    public String gotoLoginPage() {
//        //logger.debug("Name: {}",name);
//        return "login";
//    }
//
//    @RequestMapping(value="login", method = RequestMethod.POST)
//    public String gotoWelcomePage(@RequestParam String name, @RequestParam String password, ModelMap model) {
//        //logger.debug("Name: {}",name);
//        if (authenticationService.authenticate(name, password)) {
//            model.put("name", name);
//            return "welcome";
//        }
//
//        model.put("errorMessage", "Invalid Credentials!!");
//        return "login";
//    }
//}
