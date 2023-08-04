import React from 'react'

const Payment = () => {

    const [amount, setamount] = React.useState('');

  const handleSubmit = (e)=>{
    e.preventDefault();
    if(amount === ""){
    alert("please enter amount");
    }else{
      var options = {
        key: "rzp_test_ptZiEyaQBXWK5X",
        key_secret:"5L4mup2uHzEmhrBoDEQEYY31",
        amount: amount *100,
        currency:"INR",
        name:"Spark Tourism",
        description:"Payment Testing",
        prefill: {
          name:"Vishal",
          email:"vishalbharathkumar@gmail.com",
          contact:"8754550424"
        },
        notes:{
          address:"Razorpay Corporate office"
        },
        theme: {
          color:"#3399cc"
        }
      };
      var pay = new window.Razorpay(options);
      pay.open();
    }
}

  return (
    <div>
        <div className="App">
     <br/>
     <input type="text"placeholder='Enter Amount'value={amount}onChange={(e)=>setamount(e.target.value)} />
     <br/><br/>
     <button onClick={handleSubmit}>submit</button>
    </div>
    </div>
  )
}

export default Payment