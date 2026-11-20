function LoginStatus({isLoggedIn}) {
    return (
        <div>
            {isLoggedIn ? (
                <h2>Welcome back!</h2>
            ) : (
                <h2>Please Login</h2>
            )}
        </div>
    );
}

export function Notification({hasMessage}) {
    return (
        <div>
            {hasMessage && <p>You Have a message.</p>}
        </div>
    );
}

export function Dashboard({role}) {
    if(role==="admin") {
        return <h1>Admin Dashboard</h1>
    }
}

export default LoginStatus;