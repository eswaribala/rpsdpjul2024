using ChainofResponsibilityAuthenticationApp;
using System.Buffers.Text;

namespace ChainofResponsibilityAuthenticationApp
{
    public interface AuthenticationHandler
    {
        bool authenticate(Request request);
        void next(AuthenticationHandler nextHandler, Request request);
    }

    public class BasicAuthenticationHandler : AuthenticationHandler
    {

        override
    public bool authenticate(Request request)
    {
        // Check basic authentication credentials
        String username = request.getHeader("Authorization");
        if (username != null && username.StartsWith("Basic "))
        {
            String decodedUsername = Base64.getDecoder().decode(username.substring(6));
            if (decodedUsername.equals("user") && request.getHeader("Password").equals("password"))
            {
                return true;
            }
        }
        return false;
    }

    @Override
    public void next(AuthenticationHandler nextHandler, Request request)
    {
        if (!authenticate(request))
        {
            if (nextHandler != null)
            {
                nextHandler.next(null, request);
            }
            else
            {
                // Authentication failed
                request.setResponse("Unauthorized", 401);
            }
        }
    }
}

public class RoleBasedAuthorizationHandler implements AuthenticationHandler
{

    @Override
    public boolean authenticate(Request request)
{
    // Check if the user has been authenticated by a previous handler
    if (!request.isAuthenticated())
    {
        return false;
    }
    // Check if the user has the required role
    String role = request.getHeader("Role");
    if (role != null && role.equals("admin"))
    {
        return true;
    }
    return false;
}

@Override
    public void next(AuthenticationHandler nextHandler, Request request)
{
    if (!authenticate(request))
    {
        // Authorization failed
        request.setResponse("Forbidden", 403);
    }
    else
    {
        // Authorization successful, proceed to the next handler if there is one
        if (nextHandler != null)
        {
            nextHandler.next(null, request);
        }
        else
        {
            // Authorization successful, proceed with the request
            request.process();
        }
    }
}
}

public class Request
{
    private boolean authenticated = false;
    private String response = "";

    public boolean isAuthenticated()
    {
        return authenticated;
    }

    public void setAuthenticated(boolean authenticated)
    {
        this.authenticated = authenticated;
    }

    public String getResponse()
    {
        return response;
    }

    public void setResponse(String response, int statusCode)
    {
        this.response = response;
        System.out.println("Response: " + response + " (Status Code: " + statusCode + ")");
    }

    public void process()
    {
        System.out.println("Processing request...");
    }

    public String getHeader(String headerName)
    {
        // Simulation of retrieving header values from a request object
        if (headerName.equals("Authorization"))
        {
            return "Basic dXNlcjpwYXNzd29yZA==";
        }
        else if (headerName.equals("Role"))
        {
            return "admin";
        }
        else
        {
            return null;
        }
    }
}

public class Client
{

    public static void main(String[] args)
    {
        Request request = new Request();

        AuthenticationHandler basicAuthHandler = new BasicAuthenticationHandler();
        AuthenticationHandler authorizationHandler = new RoleBasedAuthorizationHandler();

        basicAuthHandler.next(authorizationHandler, request);
    }
}
}
