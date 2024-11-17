const strengthMeter = document.getElementById("strengthMeter");
const getDetailsOfPassword = () => {
    const password = document.getElementById("passwordUpdate").value;
    return password;
}
const checkPassword = async () => {
    const password = getDetailsOfPassword();

    try {
        const responsePost = await fetch(`https://localhost:44379/api/Users/password`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(password)
        });
        const responseData = await responsePost.json();
        colorMater(responseData);
        if (!responsePost.ok) {

            if (responsePost.status === 400) throw new Error("Password is too weak");
            throw new Error("Something went wrong, try again");
        }
        else
            alert("Password is strong enough!");


    }
    catch (error) {
        alert(error.message);
    }
};


const colorMater = (responseData) => {
    strengthMeter.value = responseData;
}
const editValueOfUpdatePage = () => {
    const userName = document.querySelector("#userNameUpdate")
    const password = document.querySelector("#passwordUpdate")
    const firstName = document.querySelector("#firstNameUpdate")
    const lastName = document.querySelector("#lastNameUpdate")
    const currentUser = JSON.parse(sessionStorage.getItem("user"))
    userName.value = currentUser.userName
    password.value = currentUser.password
    firstName.value = currentUser.firstName
    lastName.value = currentUser.lastName
    checkPassword();

}
editValueOfUpdatePage()
const getAllDetilesForUpdate = () => {
    return newUser = {
        UserName: document.querySelector("#userNameUpdate").value,
        Password: document.querySelector("#passwordUpdate").value,
        FirstName: document.querySelector("#firstNameUpdate").value,
        LastName: document.querySelector("#lastNameUpdate").value
    }
}
const updateUser = async () => {
    const updateUser = getAllDetilesForUpdate()

    const currentUser = JSON.parse(sessionStorage.getItem("user"))
    //if (strengthMeter.value < 3)
    //    alert("Password is too weak")
    try {
        const responseput = await fetch(`https://localhost:44379/api/Users/${currentUser.userId}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(updateUser)
        })
        console.log(responseput)
      
        if (responseput.status == 204) {
            alert(`The user  ${currentUser.firstName}  details updated successfully!`)
            window.location.href = "Login.html";
        }
           else if (responseput.status === 401) throw new Error("Password is not strong enght ");
          
        
        else
            alert("Something went wrong, try again");
        
            
    }
    
    catch (error) {
 alert (error)
    }

}

