<h1>csharp-algorithms-and-simulation-suite</h1>
<p>Modular computational engineering suite in C# (.NET): heuristic A* and Dijkstra pathfinding, numerical projectile dynamics, Conway's Game of Life, thread synchronization, and discrete inventory modeling</p>

<h2>Project description</h2>
<p>This repository provides a unified, cross-platform algorithmic suite implemented in modern C# (.NET) spanning graph traversal, dynamic system simulation, concurrent process synchronization, and business operations research:</p>
<ol>
  <li>
    <dl>
      <dt><b>Graph Traversal &amp; Spatial Pathfinding:</b></dt>
      <dd><b>A* Search Algorithm:</b> Evaluates optimal routes on a 2D grid containing obstacles using Manhattan distance heuristics ($h(n) = |\Delta x| + |\Delta y|$) and cost scores ($f(n) = g(n) + h(n)$).</dd>
      <dd><b>Dijkstra's Algorithm:</b> Solves single-source shortest path problems on weighted adjacency matrices with non-negative edge weights.</dd>
    </dl>
  </li>
  <li>
    <dl>
      <dt><b>Computational Dynamics &amp; Simulation:</b></dt>
      <dd><b>Ballistic Projectile Motion:</b> Solves coupled differential equations for 2D trajectories subject to gravitational acceleration and linear drag ($F_{\text{drag}} = -k \cdot v$) using numerical Euler forward integration.</dd>
      <dd><b>Conway's Game of Life:</b> Simulates a 2D cellular automaton governed by discrete neighbor counting and deterministic survival/reproduction transitions.</dd>
    </dl>
  </li>
  <li>
    <dl>
      <dt><b>Process Synchronization (Petri Net Intersection):</b></dt>
      <dd>Coordinates 10 concurrent vehicle threads accessing a shared intersection resource using <code>SemaphoreSlim</code> primitives to prevent race conditions and starvation.</dd>
    </dl>
  </li>
  <li>
    <dl>
      <dt><b>Discrete Inventory Operations:</b></dt>
      <dd>Models threshold inventory replenishments governed by minimum safety stocks and reorder triggers.</dd>
    </dl>
  </li>
</ol>

<h2>Project files</h2>
<table>
  <tr>
    <th colspan="2">csharp-algorithms-and-simulation-suite</th>
  </tr>
  <tr>
    <td>src/Program.cs</td>
    <td>Master CLI entry point providing interactive menu selection and direct argument routing</td>
  </tr>
  <tr>
    <td>src/Algorithms/AStarPathfinding.cs</td>
    <td>A* grid-based pathfinding engine with open/closed set tracking and parent back-tracing</td>
  </tr>
  <tr>
    <td>src/Algorithms/DijkstraGraph.cs</td>
    <td>Dijkstra shortest path evaluator operating on weighted adjacency matrices</td>
  </tr>
  <tr>
    <td>src/Simulation/ProjectileMotion.cs</td>
    <td>Euler numerical solver for projectile motion with aerodynamic drag</td>
  </tr>
  <tr>
    <td>src/Simulation/CellularAutomaton.cs</td>
    <td>2D grid cellular automaton engine modeling Conway's Game of Life</td>
  </tr>
  <tr>
    <td>src/Concurrency/IntersectionSimulator.cs</td>
    <td>Multithreaded traffic synchronization model using SemaphoreSlim</td>
  </tr>
  <tr>
    <td>src/Business/InventoryController.cs</td>
    <td>Discrete inventory reordering state machine</td>
  </tr>
  <tr>
    <td>src/AlgorithmsSuite.csproj</td>
    <td>Cross-platform .NET project file targeting net8.0</td>
  </tr>
  <tr>
    <td>README.md</td>
    <td>Architectural documentation and mathematical overview</td>
  </tr>
  <tr>
    <td>.gitignore</td>
    <td>Exclusion rules for binaries (bin/obj), build artifacts, and IDE configurations</td>
  </tr>
</table>

<h2>Methodological Formulation</h2>
<table>
  <tr>
    <th>Module</th>
    <th>Algorithm / Concept</th>
    <th>Mathematical / Computational Formulation</th>
  </tr>
  <tr>
    <td><b>Pathfinding</b></td>
    <td>A* Evaluation Function</td>
    <td>$f(n) = g(n) + h(n), \quad h(n) = |x_n - x_{\text{target}}| + |y_n - y_{\text{target}}|$</td>
  </tr>
  <tr>
    <td><b>Graph Theory</b></td>
    <td>Dijkstra Relaxation</td>
    <td>$\text{dist}[v] = \min(\text{dist}[v], \; \text{dist}[u] + w(u, v))$</td>
  </tr>
  <tr>
    <td><b>Physics</b></td>
    <td>Euler Drag Integration</td>
    <td>$a_x = \frac{-k v_x}{m}, \quad a_y = \frac{-mg - k v_y}{m}, \quad v_{t+\Delta t} = v_t + a \Delta t$</td>
  </tr>
  <tr>
    <td><b>Automata</b></td>
    <td>Game of Life Transitions</td>
    <td>$S_{t+1}(r, c) = \begin{cases} 1 & \text{if } N=3 \lor (S_t=1 \land N=2) \\ 0 & \text{otherwise} \end{cases}$</td>
  </tr>
  <tr>
    <td><b>Concurrency</b></td>
    <td>Critical Section Gate</td>
    <td>$\text{Wait}() \to \text{Execute Critical Section} \to \text{Release}()$ via <code>SemaphoreSlim(1)</code></td>
  </tr>
</table>

<h2>Installation and launch</h2>
<ol>
  <b>
    <li>
      <dl>
        <dt>Clone repository</dt>
        <dd><code>git clone https://github.com/Kyoryuu-lab/csharp-algorithms-and-simulation-suite.git</code></dd>
        <dd><code>cd csharp-algorithms-and-simulation-suite</code></dd>
      </dl>
    </li>
  </b>
  <b>
    <li>
      <dl>
        <dt>Run via .NET CLI (cross-platform on macOS, Linux, Windows)</dt>
        <dd>Launch interactive menu: <code>dotnet run --project src/AlgorithmsSuite.csproj</code></dd>
        <dd>Launch targeted module: <code>dotnet run --project src/AlgorithmsSuite.csproj -- astar</code></dd>
        <dd>Available module targets: <code>astar</code>, <code>dijkstra</code>, <code>physics</code>, <code>life</code>, <code>concurrency</code>, <code>inventory</code></dd>
      </dl>
    </li>
  </b>
</ol>

<h2>Example of console output (dotnet run --project src/AlgorithmsSuite.csproj -- astar)</h2>
<samp>
  <p>
    --- A* Wegsuche auf 2D-Gitter ---<br />
    Gefundener optimaler Pfad (Start -&gt; Ziel):<br />
    &nbsp;&nbsp;-&gt; (0, 0)<br />
    &nbsp;&nbsp;-&gt; (1, 0)<br />
    &nbsp;&nbsp;-&gt; (2, 0)<br />
    &nbsp;&nbsp;-&gt; (2, 1)<br />
    &nbsp;&nbsp;-&gt; (2, 2)<br />
    &nbsp;&nbsp;-&gt; (2, 3)<br />
    &nbsp;&nbsp;-&gt; (2, 4)<br />
    &nbsp;&nbsp;-&gt; (3, 4)<br />
    &nbsp;&nbsp;-&gt; (4, 4)
  </p>
