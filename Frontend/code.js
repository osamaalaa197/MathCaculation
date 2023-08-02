async function calculate() {
    const operand = document.getElementById("operand").value;
    if (!operand) {
      alert("Please enter an operand.");
      return;
    }

    const response = await fetch(`https://localhost:7220/api/Math/Calculate?data=${operand}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
    });

    if (response.ok) {
      const result = await response.json();
      document.getElementById(
        "result"
      ).textContent = `${result.operand} << ${result.operand} = ${result.result}`;
    } else {
      const errorResponse = await response.json();
      alert("Error: " + errorResponse);
    }
  }